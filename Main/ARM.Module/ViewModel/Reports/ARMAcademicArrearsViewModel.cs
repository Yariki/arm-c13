using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Serialization;
using ARM.Data.Models;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.Reports.View;
using ARM.Module.Interfaces.Reports.ViewModel;
using ARM.Module.ViewModel.Reports.AcademicArrears;
using ARM.Module.ViewModel.Reports.LetterTemplate;
using ARM.Resource.AppResource;
using ManagedExcel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Novacode;
using Application = System.Windows.Application;
using Border = Novacode.Border;

namespace ARM.Module.ViewModel.Reports
{
    /// <summary>
    ///     Модель представлення для формування списків студентів з академічною заборгованістю.
    /// </summary>
    public class ARMAcademicArrearsViewModel : ARMReportGroupSessionViewModelBase, IARMAcademicArrearsViewModel
    {
        private const string date = "*DATE*";
        private const string parent = "*PARENT*";
        private const string student = "*STUDENT*";

        private IEnumerable<Guid> _listClasses = null;

        /// <summary>
        ///     Створити екземпляр <see cref="ARMAcademicArrearsViewModel" /> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="view">The view.</param>
        public ARMAcademicArrearsViewModel(IRegionManager regionManager, IUnityContainer unityContainer,
            IEventAggregator eventAggregator, IARMAcademicArrearsView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        #region IARMAcademicArrearsViewModel Members

        /// <summary>
        ///     Заголовок вкладки.
        /// </summary>
        public override string Title
        {
            get { return Resources.Report_AcademicArrears_Title; }
        }

        #endregion IARMAcademicArrearsViewModel Members

        #region [properties]

        /// <summary>
        ///     Отримує або задає дані.
        /// </summary>
        public ObservableCollection<ARMStudentAcademicArrearsData> DataSource
        {
            get { return Get(() => DataSource); }
            set { Set(() => DataSource, value); }
        }

        /// <summary>
        ///     Отримує або задає обраного студента та його інформацію з успішності.
        ///     Використовується при подальшому генеруванні листа.
        /// </summary>
        public ARMStudentAcademicArrearsData SelectedItem
        {
            get { return Get(() => SelectedItem); }
            set { Set(() => SelectedItem, value); }
        }

        /// <summary>
        ///     Отримує команду для формування звіту/списків.
        /// </summary>
        public ICommand RunCommand { get; private set; }

        /// <summary>
        ///     Отримує або задає команду для створення листа.
        /// </summary>
        public ICommand CreateLetterCommand { get; private set; }

        /// <summary>
        /// Отримує або задає флаг для відкриття документів.
        /// </summary>
        public bool ShouldOpenDocument
        {
            get { return Get(() => ShouldOpenDocument); }
            set { Set(() => ShouldOpenDocument, value); }
        }

        /// <summary>
        /// Отримує або зажає шлях для збереження листів.
        /// </summary>
        public string SaveLetterPath
        {
            get { return Get(() => SaveLetterPath); }
            set { Set(() => SaveLetterPath, value); }
        }

        #endregion [properties]

        #region [override]

        /// <summary>
        ///     Ініціалізація екземпляру.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            RunCommand = new ARMRelayCommand(RunExecute, CanRunExecute);
            CreateLetterCommand = new ARMRelayCommand(CreateLetterExecute, CanCreateLetterExecute);
            SaveLetterPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            ShouldOpenDocument = false;
        }


        protected override int GenerateHeaders(Worksheet sheet)
        {
            int row = 1;
            int col = 1;
            SheetManipulator.SetSheetCellValue(sheet,row,col,Resource.AppResource.Resources.Model_Student_Title);
            SheetManipulator.SetSheetCellWidth(sheet,row,col++,25);
            foreach (var source in SelectedSession.Classes.Where(c => _listClasses.Contains(c.Id)).OrderBy(c => c.Id))
            {
                SheetManipulator.SetSheetCellWidth(sheet, row, col, 25);
                SheetManipulator.SetSheetCellValue(sheet, row, col++, source.Name);
            }
            return ++row;
        }

        protected override void FillSheet(Worksheet sheet, int rowStart)
        {
            int current = 0;
            foreach (var student in DataSource)
            {
                int col = 1;
                SheetManipulator.SetSheetCellValue(sheet,rowStart,col,student.Student.Display);
                foreach (var source in SelectedSession.Classes.Where(c => _listClasses.Contains(c.Id)).OrderBy(c => c.Id))
                {
                    var rate = student[source.Id.ToString().ToLower()] as List<ARMAcademicArrearsDetails>;
                    var result = rate != null && rate.Any() ? string.Format("{0} ({1})", rate[0].Name, rate[0].Rate) : string.Empty;
                    SheetManipulator.SetSheetCellValue(sheet, rowStart, ++col, result);
                    if (!string.IsNullOrEmpty(result))
                    {
                        SheetManipulator.SetSheetCellBackgroundColor(sheet, rowStart, col, Color.LightPink);
                    }
                }
                rowStart++;
                current++;
                UpdateProgress(current,DataSource.Count);
            }
        }

        #endregion [override]

        #region [private]

        private void RunExecute(object arg)
        {
            if (DataSource != null)
            {
                DataSource.Clear();
            }
            IsBusy = true;
            Task.Factory.StartNew(InternalProcessRun);
        }

        private void InternalProcessRun()
        {
            try
            {
                IEnumerable<Guid> listStudent = SelectedGroup.Students.Select(s => s.Id);
                IEnumerable<Guid> listClass = SelectedSession.Classes.Select(c => c.Id);
                Rate lowRate = UnitOfWork.RateRepositary.GetLowRate();
                var result = UnitOfWork.MarkRepository.GetMarkAccordingStudentsAndClasses(listStudent, listClass)
                    .Where(m => m.Type != MarkType.Certification)
                    .GroupBy(m => new {m.StudentId, m.ClassId})
                    .Select(g => new {g.Key.StudentId, g.Key.ClassId, Sum = g.Sum(m => m.MarkRate)})
                    .Where(r => r.Sum >= lowRate.RateMin && r.Sum < lowRate.RateMax)
                    .ToList();

                var data = new ObservableCollection<ARMStudentAcademicArrearsData>();
                _listClasses = result.Select(r => r.ClassId).Distinct().Select(g => g.Value);
                foreach (var group in result.GroupBy(r => r.StudentId))
                {
                    var st = new ARMStudentAcademicArrearsData
                    {
                        Student = SelectedGroup.Students.FirstOrDefault(s => s.Id == group.Key.Value)
                    };
                    foreach (var mark in group)
                    {
                        st[mark.ClassId.ToString().ToLower()] = new ARMAcademicArrearsDetails
                        {
                            Name = lowRate.Name,
                            Rate = mark.Sum
                        };
                    }
                    data.Add(st);
                }

                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    GenerateColumns(_listClasses);
                    DataSource = data;
                    IsBusy = false;
                }));
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
                IsBusy = false;
            }
        }

        private bool CanRunExecute(object arg)
        {
            return !IsBusy && SelectedGroup != null && SelectedSession != null;
        }

        private void CreateLetterExecute(object arg)
        {
            IsBusy = true;

            Task.Factory.StartNew(InternalGeneratingLetter);
        }

        private void InternalGeneratingLetter()
        {
            SetLocal();
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments),
                    string.Format("{0}_{1}_Academic_Letter.docx", SelectedItem.Student.LastName,
                        SelectedItem.Student.FirstName));

                ARMLetterTemplate lettertemplate = null;
                var serializer = new XmlSerializer(typeof (ARMLetterTemplate));
                using (TextReader reader = new StringReader(Resources.Letter_Academic_Template))
                {
                    //reader.ReadToEnd();
                    lettertemplate = (ARMLetterTemplate) serializer.Deserialize(reader);
                }

                DocX doc = DocX.Create(path);
                var titleFormat = new Formatting
                {
                    Size = 18D,
                    Position = 12
                };

                var bodyFormat = new Formatting
                {
                    Bold = false,
                    Size = 11D
                };

                Paragraph title = doc.InsertParagraph(lettertemplate.Header, false, titleFormat);
                title.Alignment = Alignment.center;
                doc.InsertParagraph(Environment.NewLine);
                doc.InsertParagraph(lettertemplate.Body, false, bodyFormat);
                doc.InsertParagraph(Environment.NewLine);
                doc.InsertParagraph(lettertemplate.Footer, false, bodyFormat);
                doc.InsertParagraph(Environment.NewLine);
                doc.InsertParagraph(Environment.NewLine);
                Paragraph tableName = doc.InsertParagraph(Resources.Table_Success);
                tableName.Alignment = Alignment.center;

                Table table = doc.InsertTable(SelectedItem.Count, 3);
                for (int i = 0; i < SelectedItem.Count; i++)
                {
                    KeyValuePair<string, List<ARMAcademicArrearsDetails>> keyValue = SelectedItem.GetKeyValue(i);
                    Class classSession =
                        SelectedSession.Classes.FirstOrDefault(c => c.Id.ToString().ToLowerInvariant() == keyValue.Key);
                    if (classSession != null)
                    {
                        table.Rows[i].Cells[0].Paragraphs.First().Append(classSession.Display);
                    }
                    table.Rows[i].Cells[1].Paragraphs.First().Append(keyValue.Value[0].Name);
                    table.Rows[i].Cells[2].Paragraphs.First().Append(keyValue.Value[0].Rate.ToString());

                    foreach (Cell cell in table.Rows[i].Cells)
                    {
                        cell.SetBorder(TableCellBorderType.Bottom,
                            new Border(BorderStyle.Tcbs_single, BorderSize.one, 1, Color.Black));
                        cell.SetBorder(TableCellBorderType.Top,
                            new Border(BorderStyle.Tcbs_single, BorderSize.one, 1, Color.Black));
                        cell.SetBorder(TableCellBorderType.Left,
                            new Border(BorderStyle.Tcbs_single, BorderSize.one, 1, Color.Black));
                        cell.SetBorder(TableCellBorderType.Right,
                            new Border(BorderStyle.Tcbs_single, BorderSize.one, 1, Color.Black));
                    }
                }

                doc.ReplaceText(date, DateTime.Now.Date.ToShortDateString());
                Student st = UnitOfWork.StudentRepository.GetById(SelectedItem.Student.Id);
                if (st != null && st.Parents.Any())
                {
                    doc.ReplaceText(parent, SelectedItem.Student.Parents.First().Display);
                }
                doc.ReplaceText(student, SelectedItem.Student.Display);
                doc.Save();
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (ShouldOpenDocument)
                    {
                        Process.Start(path);
                    }
                }));
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool CanCreateLetterExecute(object arg)
        {
            return SelectedItem != null;
        }

        #endregion [private]
    }
}