using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Infrastructure.MVVM;
using ARM.Module.Helpers.AttachedProperty;
using ARM.Module.Interfaces.Reports.View;
using ARM.Module.Interfaces.Reports.ViewModel;
using ARM.Module.ViewModel.Reports.Certification;
using ManagedExcel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using DataGrid = Xceed.Wpf.DataGrid;

namespace ARM.Module.ViewModel.Reports
{
    public class ARMCertificationViewModel : ARMReportViewModelBase, IARMCertificationViewModel
    {
        public ARMCertificationViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMCertificationView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        public override string Title
        {
            get { return Resource.AppResource.Resources.Report_Certification_Title; }
        }

        #region [properties]

        public ObservableCollection<Group> Groups
        {
            get { return Get(() => Groups); }
            set { Set(() => Groups, value); }
        }

        public ObservableCollection<Session> Sessions
        {
            get { return Get(() => Sessions); }
            set { Set(() => Sessions, value); }
        }

        public Group SelectedGroup
        {
            get { return Get(() => SelectedGroup); }
            set { Set(() => SelectedGroup, value); }
        }

        public Session SelectedSession
        {
            get { return Get(() => SelectedSession); }
            set { Set(() => SelectedSession, value); }
        }

        public ObservableCollection<ARMStudentCertificationData> DataSource
        {
            get { return Get(() => DataSource); }
            set { Set(() => DataSource, value); }
        }

        public ObservableCollection<DataGridColumn> Columns
        {
            get { return Get(() => Columns); }
            set { Set(() => Columns, value); }
        }


        public ICommand RunCommand { get; private set; }

        #endregion

        #region [overrides]

        public override void Initialize()
        {
            base.Initialize();
            Groups = new ObservableCollection<Group>(UnitOfWork.GroupRepository.GetAll());
            Sessions = new ObservableCollection<Session>(UnitOfWork.SessionRepository.GetAll());
            SelectedGroup = null;
            SelectedSession = null;
            RunCommand = new ARMRelayCommand(RunExecute, CanRunExecute);
            Columns = new ObservableCollection<DataGridColumn>();
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
                int shift = 0;
                foreach (var listClass in listClasses)
                {
                    col++;
                    var cert = student[listClass.ToString().ToLower()] as List<ARMCertificationDetailsData>;
                    if (cert == null)
                        continue;
                    for (int i = 0; i < cert.Count; i++)
                    {
                        SheetManipulator.SetSheetCellValue(sheet, row + i, col, string.Format("{0:d}", cert[i].Date));
                        SheetManipulator.SetSheetCellBackgroundColor(sheet, row + i, col, cert[i].IsCertificated ? System.Drawing.Color.LightGreen : System.Drawing.Color.Pink);
                        if (i > shift)
                            shift = i;
                    }
                }
                SheetManipulator.SetSheetRangeBorder(sheet, row, 1, row + shift, listClasses.Count + 1, XlLineStyle.xlContinuous, XlBorderWeight.xlThin);
                row += shift > 0 ? ++shift : 1;
                current++;
                UpdateProgress(current, DataSource.Count);
            }
        }

        protected override bool CanExportExecute(object arg)
        {
            return DataSource != null && DataSource.Count > 0;
        }

        #endregion

        #region [private]

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
            Task.Factory.StartNew(ProcessReport);
        }

        private void ProcessReport()
        {
            var data = new ObservableCollection<ARMStudentCertificationData>();
            var listStudents = SelectedGroup.Students.Select(s => s.Id);
            var listClasses = SelectedSession.Classes.Select(c => c.Id);
            var marks =
                UnitOfWork.MarkRepository.GetAll(
                    new Func<Mark, bool>(
                        m =>
                            listStudents.Contains(m.StudentId.Value) && listClasses.Contains(m.ClassId.Value) &&
                            m.Type == MarkType.Certification)).GroupBy(m => new { m.StudentId, m.ClassId });
            foreach (var mark in marks)
            {
                var studentCert = AddAndGetData(data, mark.Key.StudentId.Value);
                foreach (var mark1 in mark.OrderBy(m => m.ClassId).ThenBy(m => m.Date))
                {
                    studentCert[mark.Key.ClassId.ToString().ToLower()] = new ARMCertificationDetailsData()
                    {
                        Name = mark1.Name,
                        IsCertificated = mark1.IsCertification,
                        Date = mark1.Date.Value
                    };
                }
            }

            System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                GenerateColumns();
                DataSource =
                    new ObservableCollection<ARMStudentCertificationData>(data.OrderBy(d => d.Student.Display).AsEnumerable());
                IsBusy = false;    
            }));
        }

        private ARMStudentCertificationData AddAndGetData(ObservableCollection<ARMStudentCertificationData> list, Guid id)
        {
            var data = list.FirstOrDefault(s => s.Student.Id == id);
            if (data == null)
            {
                var st = new ARMStudentCertificationData() { Student = SelectedGroup.Students.First(s => s.Id == id) };
                list.Add(st);
                return st;
            }
            return data;
        }

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

        private bool CanRunExecute(object arg)
        {
            return SelectedGroup != null && SelectedSession != null;
        }

        #endregion
    }
}