using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Infrastructure.Facade;
using ManagedExcel;
using Microsoft.Office.Interop.Excel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Microsoft.Win32;
using Worksheet = ManagedExcel.Worksheet;
using XlSaveAsAccessMode = ManagedExcel.XlSaveAsAccessMode;

namespace ARM.Infrastructure.MVVM
{
    /// <summary>
    /// Базовий клас для звітів.
    /// </summary>
    public abstract class ARMReportViewModelBase : ARMWorkspaceViewModelBase, IARMReportViewModel
    {
        /// <summary>
        /// Ініціалізує новий екземпляр класу <see cref="ARMReportViewModelBase"/>.
        /// </summary>
        /// <param name="regionManager">Менеджер регіонів.</param>
        /// <param name="unityContainer">Контейнер IoC.</param>
        /// <param name="eventAggregator">Агрегатор подій.</param>
        /// <param name="view">The view.</param>
        protected ARMReportViewModelBase(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            ExportCommand = new ARMRelayCommand(ExportExecute, CanExportExecute);
        }

        #region [properties]

        /// <summary>
        /// Команда для експорту даних звіту
        /// </summary>
        public ICommand ExportCommand { get; private set; }

        /// <summary>
        /// Встановлює або повертає прогрес експорту.
        /// </summary>
        public int Progress
        {
            get { return Get(() => Progress); }
            set { Set(() => Progress, value); }
        }

        /// <summary>
        /// Втановлює або повертає статус експорту.
        /// </summary>
        public string Status
        {
            get { return Get(() => Status); }
            set { Set(() => Status, value); }
        }

        #endregion [properties]

        /// <summary>
        /// Виконання експорту.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        private void ExportExecute(object arg)
        {
            GenerateReport();
        }

        /// <summary>
        /// Визначає, чи є цей екземпляр [може експортувати виконати] зазначений аргумент.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        /// <returns></returns>
        protected virtual bool CanExportExecute(object arg)
        {
            return true;
        }

        /// <summary>
        /// Заповнення листа даними при еспорті.
        /// </summary>
        /// <param name="sheet">Лист.</param>
        /// <param name="rowStart">Номер рідка, з якого потрібно почитнати заповнення.</param>
        protected virtual void FillSheet(Worksheet sheet, int rowStart)
        {
        }

        /// <summary>
        /// Створює заголовки.
        /// </summary>
        /// <param name="sheet">Лист.</param>
        /// <returns></returns>
        protected virtual int GenerateHeaders(Worksheet sheet)
        {
            return 1;
        }

        /// <summary>
        /// Перевіряє параметр звіту.
        /// </summary>
        /// <param name="name">Назва параметру.</param>
        /// <returns></returns>
        protected virtual string ValidateReportParameter(string name)
        {
            return string.Empty;
        }

        /// <summary>
        /// Очищає прогрес.
        /// </summary>
        protected void ClearProgress()
        {
            Progress = 0;
        }

        /// <summary>
        /// Перераховує прогрес.
        /// </summary>
        /// <param name="current">Поточний запис.</param>
        /// <param name="count">Загальна кількість.</param>
        protected void UpdateProgress(int current, int count)
        {
            Progress = ((current / count) * 100);
        }

        #region [private]

        /// <summary>
        /// Запуск генерації звіту.
        /// </summary>
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

        /// <summary>
        /// Еспорт звіту.
        /// </summary>
        /// <param name="filename">Назва файлу.</param>
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

        /// <summary>
        /// Встановлює локаль для потоку, в якому виконується екпорт звіту.
        /// </summary>
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

        #endregion [private]

        /// <summary>
        /// Повертає повідомлення у відповідності до переданої колонки.
        /// </summary>
        /// <param name="columnName">Назва колонки.</param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get { return ValidateReportParameter(columnName); }
        }

        /// <summary>
        /// Повертає повідомлення помилки.
        /// </summary>
        public virtual string Error
        {
            get { return string.Empty; }
        }
    }
}