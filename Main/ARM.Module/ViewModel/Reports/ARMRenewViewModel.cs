using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using ARM.Data.Models;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.Reports.View;
using ARM.Module.Interfaces.Reports.ViewModel;
using ARM.Module.ViewModel.Reports.LetterTemplate;
using ARM.Module.ViewModel.Reports.Renew;
using ARM.Resource.AppResource;
using ManagedExcel;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Novacode;
using Application = System.Windows.Application;
using Border = Novacode.Border;

namespace ARM.Module.ViewModel.Reports
{
    public class ARMRenewViewModel : ARMReportGroupSessionViewModelBase, IARMRenewViewModel
    {
        public ARMRenewViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMRenewView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        public override string Title
        {
            get { return Resource.AppResource.Resources.Report_Renew_Title; }
        }

        #region [properties]

        public ObservableCollection<ARMCheckboxWraper<Group>> GroupsCheck
        {
            get { return Get(() => GroupsCheck); }
            set { Set(() => GroupsCheck, value); }
        }

        public ICommand RunCommand { get; private set; }

        public ICommand WordSaveCommand { get; private set; }

        public ObservableCollection<ARMStudentRenewInfo> DataSource
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

        public override void Initialize()
        {
            base.Initialize();
            GroupsCheck = new ObservableCollection<ARMCheckboxWraper<Group>>(this.Groups.Select(g => new ARMCheckboxWraper<Group>(g)));
            RunCommand = new ARMRelayCommand(RunExecute, CanRunExecute);
            WordSaveCommand = new ARMRelayCommand(WordSaveExecute, CanWordExecute);
            SaveLetterPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            ShouldOpenDocument = true;
        }

        protected override bool CanExportExecute(object arg)
        {
            return DataSource != null && DataSource.Count > 0;
        }

        protected override int GenerateHeaders(Worksheet sheet)
        {
            int row = 1;

            var template = GetLetterTemplate(Resource.AppResource.Resources.Letter_Renew_Template);
            if (template != null)
            {
                SheetManipulator.SetSheetCellValue(sheet, row, 1, template.Header);
                SheetManipulator.SetSheetCellFontStyles(sheet,row,1,Color.Black,true,false);
            }
            SheetManipulator.SetSheetCellWidth(sheet, row, 1, 45);
            SheetManipulator.SetSheetCellWidth(sheet, row, 2, 75);

            return ++row;
        }

        protected override void FillSheet(Worksheet sheet, int rowStart)
        {
            int current = 0;
            foreach (var groupKey in DataSource.GroupBy(s => s.Group))
            {
                SheetManipulator.SetSheetCellValue(sheet, rowStart, 1, groupKey.Key.Display);
                SheetManipulator.SetSheetRangeBorder(sheet, rowStart, 1, rowStart, 2, XlLineStyle.xlContinuous, XlBorderWeight.xlThin);
                SheetManipulator.SetSheetCellFontStyles(sheet, rowStart, 1, Color.Blue, true, true);
                rowStart++;
                foreach (var armStudentRenewInfo in groupKey)
                {
                    SheetManipulator.SetSheetCellValue(sheet, rowStart, 2, armStudentRenewInfo.Student.Display);
                    SheetManipulator.SetSheetRangeBorder(sheet, rowStart, 1, rowStart, 2, XlLineStyle.xlContinuous, XlBorderWeight.xlThin);
                    rowStart++;
                    current++;
                }
                UpdateProgress(current,DataSource.Count);
            }
        }

        private static ARMLetterTemplate GetLetterTemplate(string letter)
        {
            ARMLetterTemplate lettertemplate = null;
            var serializer = new XmlSerializer(typeof(ARMLetterTemplate));
            using (TextReader reader = new StringReader(letter))
            {
                lettertemplate = (ARMLetterTemplate)serializer.Deserialize(reader);
            }
            return lettertemplate;
        }

        #endregion [overrides]

        #region [private]

        private void RunExecute(object arg)
        {
            if (DataSource != null)
            {
                DataSource.Clear();
            }
            IsBusy = true;
            Task.Factory.StartNew(InternalRun);
        }

        private bool CanRunExecute(object arg)
        {
            return GroupsCheck != null && GroupsCheck.Any(g => g.IsSelected);
        }

        private void InternalRun()
        {
            try
            {
                var listSelected = GroupsCheck.Where(g => g.IsSelected).Select(g => g.Value.Id);
                if (!listSelected.Any())
                    return;
                var result = new ObservableCollection<ARMStudentRenewInfo>();
                UnitOfWork.StudentRepository.GetAllRenewStudentInGroups(listSelected).Select(s => new ARMStudentRenewInfo() { Student = s, Group = s.Group }).ForEach(result.Add);
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

        private void WordSaveExecute(object arg)
        {
            IsBusy = true;
            Task.Factory.StartNew(new Action(InternalWordSave));
        }

        private bool CanWordExecute(object arg)
        {
            return DataSource != null && DataSource.Count > 0;
        }

        private void InternalWordSave()
        {
            SetLocal();
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments),
                    string.Format("{0}__Renew_{1}_{2}_{3}.docx", string.Join("_", GroupsCheck.Where(g => g.IsSelected).Select(g => g.Display)),
                        DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day));

                ARMLetterTemplate lettertemplate = GetLetterTemplate(Resources.Letter_Renew_Template);

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

                Table table = doc.InsertTable(1, 2);

                foreach (var groupKey in DataSource.GroupBy(a => a.Group))
                {
                    Row groupRow = table.InsertRow();
                    groupRow.Cells[0].Paragraphs.First().Append(groupKey.Key.Display);
                    groupRow.Cells[0].Width = 100;
                    SetBorderToRow(groupRow);
                    foreach (var armStudentRenewInfo in groupKey)
                    {
                        Row studentRow = table.InsertRow();
                        studentRow.Cells[1].Paragraphs.First().Append(armStudentRenewInfo.Student.Display);
                        studentRow.Cells[1].Width = 200;
                        SetBorderToRow(studentRow);
                    }
                }
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

        private void SetBorderToRow(Row row)
        {
            foreach (Cell cell in row.Cells)
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

        #endregion [private]
    }
}