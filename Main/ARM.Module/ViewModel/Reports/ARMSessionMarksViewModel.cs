using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Drawing;
using ARM.Data.Models;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.MVVM;
using ARM.Module.Helpers.AttachedProperty;
using ARM.Module.Interfaces.Reports.View;
using ARM.Module.Interfaces.Reports.ViewModel;
using ARM.Module.ViewModel.Reports.SessionMarks;
using ManagedExcel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.Reports
{
    /// <summary>
    /// класс, який формує звіт по успішності студентів групи за сесію. Розраховує суму балів за сесію та визначає оцінку.
    /// </summary>
    public class ARMSessionMarksViewModel : ARMReportGroupSessionViewModelBase, IARMSessionMarksViewModel
    {
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="view">The view.</param>
        public ARMSessionMarksViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMSessionMarksView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        public override string Title
        {
            get { return Resource.AppResource.Resources.Report_SessionMark_Title; }
        }

        #region [properties]

        /// <summary>
        /// Колекція даних для відображення
        /// </summary>
        /// <value>
        /// дані
        /// </value>
        public ObservableCollection<ARMStudentSessionMarksData> DataSource
        {
            get { return Get(() => DataSource); }
            set { Set(() => DataSource, value); }
        }

        /// <summary>
        /// команда ініціації формування звіту.
        /// </summary>
        public ICommand RunCommand { get; private set; }

        #endregion [properties]

        #region [overrides]

        /// <summary>
        /// ініціалізація обєкту, в нашому випадку формування команди
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            RunCommand = new ARMRelayCommand(RunExecute,CanRunExecute);
        }

        protected override int GenerateHeaders(Worksheet sheet)
        {
            int Row = 1;
            SheetManipulator.SetSheetCellWidth(sheet, Row, 1, 25);
            SheetManipulator.SetSheetCellValue(sheet, Row, 1, Resource.AppResource.Resources.Model_Student_Title);
            int col = 2;
            foreach (var cl in SelectedSession.Classes.OrderBy(c => c.Id))
            {
                SheetManipulator.SetSheetCellWidth(sheet, Row, col, 25);
                SheetManipulator.SetSheetCellValue(sheet, Row, col, cl.Name);
                col++;
            }
            return ++Row;
        }

        protected override void FillSheet(Worksheet sheet, int rowStart)
        {
            var listClasses = SelectedSession.Classes.OrderBy(c => c.Id).Select(c => c.Id).ToList();
            int current = 0;
            int row = rowStart;

            foreach (var student in DataSource)
            {
                int col = 1;
                SheetManipulator.SetSheetCellValue(sheet, row, col, student.Student.Display);
                col++;
                foreach (var classId in listClasses)
                {
                    var details = student[classId.ToString().ToLower()] as List<ARMSessionMarkDetails>;
                    if (details != null && details.Count > 0)
                    {
                        SheetManipulator.SetSheetCellBackgroundColor(sheet, row, col, ReturnColorAccordingMark(details[0].Mark));   
                        SheetManipulator.SetSheetCellValue(sheet,row,col,string.Format("{0} ({1:0.0})",details[0].Name,details[0].Rate));
                    }
                    col++;
                }
                row++;
                current++;
                UpdateProgress(current,DataSource.Count);
            }
        }

        #endregion [overrides]

        #region [private]

        /// <summary>
        /// повертая колір у відповідності до оцінки
        /// </summary>
        /// <param name="mark">Оцінка.</param>
        /// <returns>Колір</returns>
        private Color ReturnColorAccordingMark(decimal mark)
        {
            return (mark >= decimal.Zero && mark < 3)
               ? Color.OrangeRed
               : (mark >= 3 && mark < 4)
                   ? Color.Orange
                   : (mark >= 4 && mark < 5)
                       ? Color.Yellow
                       : (mark == 5) ? Color.LightGreen : Color.Transparent; 
        }

        /// <summary>
        /// запускає потік на виконання. Звіт формується в потоці.
        /// </summary>
        /// <param name="arg">Агрумент.</param>
        private void RunExecute(object arg)
        {
            IsBusy = true;
            if (DataSource != null)
            {
                DataSource.Clear();
                DataSource = null;
            }
            if (Columns != null)
            {
                Columns.Clear();
                Columns = null;
            }
            Task.Factory.StartNew(new Action(ProcessData));
        }

        /// <summary>
        /// визначає чи може команда виконуватись
        /// </summary>
        /// <param name="arg">Аргумент.</param>
        /// <returns></returns>
        private bool CanRunExecute(object arg)
        {
            return SelectedGroup != null && SelectedSession != null;
        }

        /// <summary>
        /// метод обробки данних
        /// </summary>
        private void ProcessData()
        {
            try
            {
                var data = new ObservableCollection<ARMStudentSessionMarksData>();
                var listStudents = SelectedGroup.Students.Select(s => s.Id);
                var listClasses = SelectedSession.Classes.Select(c => c.Id);
                var marks =
                    UnitOfWork.MarkRepository.GetAll(
                        new Func<Mark, bool>(
                            m =>
                                listStudents.Contains(m.StudentId.Value) && listClasses.Contains(m.ClassId.Value) &&
                                m.Type != MarkType.Coursework)).ToList();

                foreach (var studentId in listStudents)
                {
                    var studentData = new ARMStudentSessionMarksData()
                    {
                        Student = SelectedGroup.Students.FirstOrDefault(s => s.Id == studentId)
                    };
                    foreach (var classId in listClasses)
                    {
                        var sumRate = marks.Where(m => m.StudentId.Value == studentId && m.ClassId == classId).Sum(m => m.MarkRate);
                        var rate = UnitOfWork.RateRepositary.GetApproprialRate(sumRate);
                        if (rate != null)
                        {
                            var classDetails = new ARMSessionMarkDetails(){Name = rate.Name,Rate = sumRate,Mark = rate.Mark};
                            studentData[classId.ToString().ToLower()] = classDetails;
                        }
                    }
                    data.Add(studentData);
                }

                System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    GenerateColumns();
                    DataSource =
                        new ObservableCollection<ARMStudentSessionMarksData>(data.OrderBy(d => d.Student.Display).AsEnumerable());
                    IsBusy = false;
                }));
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
                IsBusy = false;
            }
        }

        /// <summary>
        /// генерація колонок
        /// </summary>
        private void GenerateColumns()
        {
            var col = new ObservableCollection<DataGridColumn>();
            var name = new DataGridTextColumn() { Width = 200, Header = Resource.AppResource.Resources.Model_Student_Title };
            name.Binding = new Binding("Student.Display") { Mode = BindingMode.OneTime };
            name.CanUserSort = false;
            col.Add(name);
            foreach (var source in SelectedSession.Classes.OrderBy(c => c.Id))
            {
                var c = new DataGridTemplateColumn() { Width = 150, Header = source.Name };
                c.SetValue(ARMDataGridTemplateColumnBinding.ColumnBindingProperty, string.Format("[{0}]", source.Id.ToString().ToLower()));
                col.Add(c);
            }
            Columns = col;
        }

        #endregion [private]
    }
}