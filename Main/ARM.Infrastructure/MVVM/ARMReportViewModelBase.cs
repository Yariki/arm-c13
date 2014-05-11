using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Infrastructure.Facade;
using Microsoft.Office.Interop.Excel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using ManagedExcel;
using Microsoft.Win32;
using Worksheet = ManagedExcel.Worksheet;
using XlSaveAsAccessMode = ManagedExcel.XlSaveAsAccessMode;

namespace ARM.Infrastructure.MVVM
{
    public abstract class ARMReportViewModelBase : ARMWorkspaceViewModelBase, IARMReportViewModel
    {
        protected ARMReportViewModelBase(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            ExportCommand = new ARMRelayCommand(ExportExecute, CanExportExecute);
        }

        #region [properties]

        public ICommand ExportCommand { get; private set; }

        public int Progress
        {
            get { return Get(() => Progress); }
            set { Set(() => Progress, value); }
        }

        public string Status
        {
            get { return Get(() => Status); }
            set { Set(() => Status, value); }
        }

        public bool IsBusy
        {
            get { return Get(() => IsBusy); }
            set { Set(() => IsBusy, value); }
        }

        #endregion



        private void ExportExecute(object arg)
        {
            GenerateReport();
        }

        protected virtual bool CanExportExecute(object arg)
        {
            return true;
        }

        protected virtual void FillSheet(Worksheet sheet, int rowStart)
        {

        }

        protected virtual int GenerateHeaders(Worksheet sheet)
        {
            return 1;
        }

        protected virtual string ValidateReportParameter(string name)
        {
            return string.Empty;
        }

        protected void ClearProgress()
        {
            Progress = 0;
        }

        protected void UpdateProgress(int current, int count)
        {
            Progress = ((current / count) * 100);
        }

        #region [private]

        private void GenerateReport()
        {
            string filename = string.Empty;
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = Resource.AppResource.Resources.Report_SaveReport;
            dlg.Filter = "XLS|*.xls";//XLSX|*.xlsx|
            var res = dlg.ShowDialog();
            if (!res.HasValue || !res.Value || string.IsNullOrEmpty(filename = dlg.FileName))
            {
                ARMSystemFacade.Instance.MessageBox.ShowWarning(Resource.AppResource.Resources.Report_EmptyPath);
                return;
            }
            ClearProgress();
            Status = Resource.AppResource.Resources.Report_Status_Start;
            IsBusy = true;
            Task.Factory.StartNew(new Action(() => InternalExport(filename)));
        }

        private void InternalExport(string filename)
        {
            SetLocal();
            try
            {
                using (var exelApp = ExcelApplication.Create())
                {
                    exelApp.SheetsInNewWorkbook = 1;
                    using (var workBooks = exelApp.Workbooks)
                    {
                        using (var workBook = workBooks.Add(Type.Missing))
                        {
                            using (var sheet = workBook.Sheets.Add(Type.Missing))
                            {
                                sheet.Activate();
                                int row = GenerateHeaders(sheet);
                                FillSheet(sheet, row);
                            }
                            workBook.SaveAs(filename, XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, XlSaveAsAccessMode.xlShared,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        }
                    }
                    exelApp.Quit();
                }
                Status = Resource.AppResource.Resources.Report_Status_Finish;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
                Status = Resource.AppResource.Resources.Report_Status_Error;
                IsBusy = false;
            }
        }

        private void SetLocal()
        {
            switch (ARMSystemFacade.Instance.CurrentUser.Language)
            {
                case eARMSystemLanguage.English:
                case eARMSystemLanguage.None:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                    break;
                case eARMSystemLanguage.Ukrainian:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("uk");
                    break;
            }
        }


        #endregion

        public string this[string columnName]
        {
            get { return ValidateReportParameter(columnName); }
        }

        public virtual string Error 
        {
            get { return string.Empty; }
        }
    }
}