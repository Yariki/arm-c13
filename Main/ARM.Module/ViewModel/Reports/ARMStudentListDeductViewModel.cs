using System.IO;
using System.Xml.Serialization;
using ARM.Data.Models;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.Reports.View;
using ARM.Module.Interfaces.Reports.ViewModel;
using ARM.Module.ViewModel.Reports.Deduct;
using ARM.Module.ViewModel.Reports.LetterTemplate;
using ARM.Resource.AppResource;
using ManagedExcel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Novacode;
using Application = System.Windows.Application;
using Border = Novacode.Border;

namespace ARM.Module.ViewModel.Reports
{
    public class ARMStudentListDeductViewModel : ARMReportGroupSessionViewModelBase, IARMStudentListDeductViewModel
    {
        private const int CountFailedCertification = 3;
        private const int CountCertificationPerClass = 2;

        private const string group = "*GROUP*";

        public ARMStudentListDeductViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMStudentListDeductView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        public override string Title
        {
            get { return Resource.AppResource.Resources.Report_Deduct_Title; }
        }

        #region [properties]

        public ICommand RunCommand { get; private set; }

        public ICommand WordUnloadCommand { get; set; }

        public ObservableCollection<ARMStudentDeduct> DataSource
        {
            get { return Get(() => DataSource); }
            set { Set(() => DataSource, value); }
        }

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

        #region [overrides]

        /// <summary>
        /// Проводить ініціалізацію вкладки і моделі представлення вцілому.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            SelectedGroup = null;
            SelectedSession = null;
            DataSource = new ObservableCollection<ARMStudentDeduct>();
            RunCommand = new ARMRelayCommand(RunExecute, CanRunExecute);
            WordUnloadCommand = new ARMRelayCommand(WordUnloadExecute,CanWordUnloadExecute);
            GenerateColumns(null);
            SaveLetterPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            ShouldOpenDocument = true;
        }

        /// <summary>
        /// Визначає, чи є цей екземпляр [може експортувати виконати] зазначений аргумент.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        /// <returns></returns>
        protected override bool CanExportExecute(object arg)
        {
            return DataSource != null && DataSource.Count > 0;
        }

        /// <summary>
        /// генерація колонок
        /// </summary>
        /// <param name="listClasses"></param>
        protected override void GenerateColumns(IEnumerable<Guid> listClasses)
        {
            var col = new ObservableCollection<DataGridColumn>();
            var name = new DataGridTextColumn() { Width = 200, Header = Resource.AppResource.Resources.Model_Student_Title };
            name.Binding = new Binding("Student.Display") { Mode = BindingMode.OneTime };
            name.CanUserSort = false;
            col.Add(name);
            var c = new DataGridTextColumn() { Width = 500, Header = Resource.AppResource.Resources.Report_Deduct_Note };
            c.Binding = new Binding("Note") { Mode = BindingMode.OneTime };
            col.Add(c);
            Columns = col;
        }

        /// <summary>
        /// Створює заголовки.
        /// </summary>
        /// <param name="sheet">Лист.</param>
        /// <returns></returns>
        protected override int GenerateHeaders(Worksheet sheet)
        {
            int row = 1;

            SheetManipulator.SetSheetCellValue(sheet, row, 1, Resource.AppResource.Resources.Model_Group_Title);
            SheetManipulator.SetSheetCellValue(sheet, row, 2, SelectedGroup.Name);
            SheetManipulator.SetSheetCellFontStyles(sheet, row, 1, Color.Black, true, false);
            SheetManipulator.SetSheetCellFontStyles(sheet, row, 2, Color.Black, true, false);

            row++;
            SheetManipulator.SetSheetCellWidth(sheet, row, 1, 25);
            SheetManipulator.SetSheetCellValue(sheet, row, 1, Resource.AppResource.Resources.Model_Student_Title);
            SheetManipulator.SetSheetCellFontStyles(sheet, row, 1, Color.Blue, true, false);

            SheetManipulator.SetSheetCellWidth(sheet, row, 2, 50);
            SheetManipulator.SetSheetCellValue(sheet, row, 2, Resource.AppResource.Resources.Report_Deduct_Note);
            SheetManipulator.SetSheetCellFontStyles(sheet, row, 2, Color.Blue, true, false);

            return ++row;
        }

        /// <summary>
        /// Заповнення листа даними при еспорті.
        /// </summary>
        /// <param name="sheet">Лист.</param>
        /// <param name="rowStart">Номер рідка, з якого потрібно почитнати заповнення.</param>
        protected override void FillSheet(Worksheet sheet, int rowStart)
        {
            int current = 0;
            foreach (var armStudentDeduct in DataSource)
            {
                SheetManipulator.SetSheetCellValue(sheet, rowStart, 1, armStudentDeduct.Student.Display);

                SheetManipulator.SetSheetCellValue(sheet, rowStart, 2, armStudentDeduct.Note);

                SheetManipulator.SetSheetRangeBorder(sheet, rowStart, 1, rowStart, 2, XlLineStyle.xlContinuous, XlBorderWeight.xlThin);

                rowStart++;
                current++;
                UpdateProgress(current, DataSource.Count);
            }
        }

        #endregion [overrides]

        #region [private]

        private bool CanRunExecute(object arg)
        {
            return SelectedGroup != null && SelectedSession != null;
        }

        private void RunExecute(object arg)
        {
            if (DataSource != null && DataSource.Count > 0)
            {
                DataSource.Clear();
            }
            IsBusy = true;
            Task.Factory.StartNew(InternalProcess);
        }

        private void InternalProcess()
        {
            SetLocal();
            try
            {
                var result = new ObservableCollection<ARMStudentDeduct>();

                var listClasses = SelectedSession.Classes.Select(c => c.Id);
                var listStudet = SelectedGroup.Students.Select(s => s.Id);
                var certFailed = UnitOfWork.MarkRepository.GetMarkAccordingStudentsAndClasses(listStudet, listClasses)
                    .Where(m => m.Type == MarkType.Certification)
                    .GroupBy(m => new { m.StudentId, m.ClassId })
                    .Select(g =>
                        new
                        {
                            StudetnId = g.Key.StudentId,
                            ClassId = g.Key.ClassId,
                            IsCertFailedAll = g.All(m => !m.IsCertification),
                            Count = g.Count(m => !m.IsCertification)
                        })
                    .Where(g => g.Count >= CountCertificationPerClass)
                    .GroupBy(d => d.StudetnId)
                    .Select(
                        g =>
                            new
                            {
                                StudentId = g.Key.Value,
                                Count = g.Count(c => c.IsCertFailedAll),
                                Classes = g.Select(a => new { a.ClassId, a.IsCertFailedAll })
                            })
                    .Where(a => a.Count >= CountFailedCertification);

                Debug.WriteLine("Cert failed");
                foreach (var cert in certFailed)
                {
                    var armStudentDeductData = new ARMStudentDeduct()
                    {
                        Student = SelectedGroup.Students.FirstOrDefault(s => s.Id == cert.StudentId)
                    };
                    armStudentDeductData.Note = string.Format("{0}: {1}", Resource.AppResource.Resources.Report_Deduct_NotSequentiallyCertification,
                        string.Join(", ",
                            cert.Classes.Select(c => SelectedSession.Classes.First(cl => cl.Id == c.ClassId).Name)));
                    result.Add(armStudentDeductData);
                }

                var rat1 = UnitOfWork.RateRepositary.GetLowRate();
                var rat2 = UnitOfWork.RateRepositary.GetLowRate60();
                var dif = listStudet.Except(certFailed.Select(c => c.StudentId).ToList());
                var sessionFailed = UnitOfWork.MarkRepository.GetMarkAccordingStudentsAndClasses(dif, listClasses)
                    .Where(m => m.Type != MarkType.Certification)
                    .GroupBy(m => new { m.StudentId, m.ClassId })
                    .Select(g =>
                            new
                            {
                                StudentId = g.Key.StudentId,
                                ClassId = g.Key.ClassId,
                                Sum = g.Sum(m => m.MarkRate)
                            })
                            .Where(a => (a.Sum >= rat1.RateMin && a.Sum <= rat1.RateMax) || (a.Sum >= rat2.RateMin && a.Sum <= rat2.RateMax))
                            .GroupBy(a => a.StudentId)
                            .Select(a => new { StudentId = a.Key.Value, Classes = a.Select(g => new { g.ClassId, g.Sum }) });

                Debug.WriteLine("Classes failed");
                foreach (var ses in sessionFailed)
                {
                    var armStudentDeduct = new ARMStudentDeduct()
                    {
                        Student = SelectedGroup.Students.First(s => s.Id == ses.StudentId)
                    };
                    armStudentDeduct.Note = string.Format("{0}: {1}",
                        Resource.AppResource.Resources.Report_Deduct_FailExam,
                        string.Join(", ",
                            ses.Classes.Select(
                                c =>
                                    string.Format("{0} ({1})",
                                        SelectedSession.Classes.First(cl => cl.Id == c.ClassId).Name, c.Sum))));
                    result.Add(armStudentDeduct);
                }

                Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    DataSource = result;
                    IsBusy = false;
                }));
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
                IsBusy = false;
            }
        }

        private void WordUnloadExecute(object arg)
        {
            IsBusy = true;
            Task.Factory.StartNew(InternalWordUnload);
        }

        private bool CanWordUnloadExecute(object arg)
        {
            return DataSource != null && DataSource.Count > 0;
        }

        private void InternalWordUnload()
        {
            SetLocal();
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments),
                    string.Format("{0}__DeductList_{1}_{2}_{3}.docx", SelectedGroup.Name,
                        DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day));

                ARMLetterTemplate lettertemplate = null;
                var serializer = new XmlSerializer(typeof (ARMLetterTemplate));
                using (TextReader reader = new StringReader(Resources.Letter_Deduct_Template))
                {
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
                doc.InsertParagraph(Environment.NewLine);
                Paragraph tableName = doc.InsertParagraph(Resources.Table_ListOfStudent);
                tableName.Alignment = Alignment.center;
                doc.InsertParagraph(Environment.NewLine);

                Table table = doc.InsertTable(DataSource.Count, 3);
                for (int i = 0; i < DataSource.Count; i++)
                {
                    var studentInfo = DataSource[i];
                    table.Rows[i].Cells[0].Paragraphs.First().Append(string.Format("{0}.", i + 1));
                    table.Rows[i].Cells[0].Width = 50;
                    table.Rows[i].Cells[1].Paragraphs.First().Append(studentInfo.Student.Display);
                    table.Rows[i].Cells[2].Paragraphs.First().Append(studentInfo.Note);
                    table.Rows[i].Cells[2].Width = 250;

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
                doc.ReplaceText(group, SelectedGroup.Name);
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

        #endregion [private]
    }
}