using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ARM.Data.Models;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.Reports.View;
using ARM.Module.Interfaces.Reports.ViewModel;
using ManagedExcel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Application = System.Windows.Application;

namespace ARM.Module.ViewModel.Reports
{
    public class ARMForeignStudentViewModel : ARMReportViewModelBase, IARMForeignStudentViewModel
    {
        public ARMForeignStudentViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMForeignStudentView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        public override string Title
        {
            get { return Resource.AppResource.Resources.Report_ForeignStudent_Title; }
        }

        #region [properties]

        public ICommand RunCommand { get; private set; }

        public ObservableCollection<Student> DataSource
        {
            get { return Get(() => DataSource); }
            set { Set(() => DataSource, value); }
        }

        #endregion [properties]

        #region [override]

        public override void Initialize()
        {
            base.Initialize();
            DataSource = new ObservableCollection<Student>();
            RunCommand = new ARMRelayCommand(RunExecute, CanRunExecute);
        }

        protected override bool CanExportExecute(object arg)
        {
            return DataSource != null && DataSource.Count > 0;
        }

        protected override int GenerateHeaders(Worksheet sheet)
        {
            int row = 1;

            SheetManipulator.SetSheetCellWidth(sheet, row, 1, 25);
            SheetManipulator.SetSheetCellValue(sheet, row, 1, Resource.AppResource.Resources.Model_Person_LastName);

            SheetManipulator.SetSheetCellWidth(sheet, row, 2, 25);
            SheetManipulator.SetSheetCellValue(sheet, row, 2, Resource.AppResource.Resources.Model_Person_FirstName);

            SheetManipulator.SetSheetCellWidth(sheet, row, 3, 25);
            SheetManipulator.SetSheetCellValue(sheet, row, 3, Resource.AppResource.Resources.Model_Person_Sex);

            SheetManipulator.SetSheetCellWidth(sheet, row, 4, 25);
            SheetManipulator.SetSheetCellValue(sheet, row, 4, Resource.AppResource.Resources.Model_Student_DateEnter);

            SheetManipulator.SetSheetCellWidth(sheet, row, 5, 50);
            SheetManipulator.SetSheetCellValue(sheet, row, 5, Resource.AppResource.Resources.Model_Address_Country);

            return ++row;
        }

        protected override void FillSheet(Worksheet sheet, int rowStart)
        {
            int current = 0;
            var groupData = DataSource.GroupBy(s => s.Group);

            foreach (var group in groupData)
            {
                SheetManipulator.SetSheetCellValue(sheet, rowStart,1, Resource.AppResource.Resources.UI_Group);
                SheetManipulator.SetSheetCellValue(sheet, rowStart, 2, group.Key.Display);
                for (int i = 1; i <= 5; i++)
                {
                    SheetManipulator.SetSheetCellBackgroundColor(sheet,rowStart,i,Color.LightSkyBlue);
                }
                rowStart++;
                foreach (var student in group)
                {
                    SheetManipulator.SetSheetCellValue(sheet, rowStart, 1, student.LastName);
                    SheetManipulator.SetSheetCellValue(sheet, rowStart, 2, student.FirstName);
                    SheetManipulator.SetSheetCellValue(sheet, rowStart, 3, student.Sex);
                    SheetManipulator.SetSheetCellValue(sheet, rowStart, 4, student.DateFirstEnter);
                    SheetManipulator.SetSheetCellValue(sheet, rowStart, 5, student.Address.Display);
                    current++;
                    rowStart++;
                }
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
            Task.Factory.StartNew(InternalProcess);
        }

        private void InternalProcess()
        {
            try
            {
                var data = UnitOfWork.StudentRepository.GetAllForeignStudent();
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    DataSource = new ObservableCollection<Student>(data);
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
            return true;
        }

        #endregion [private]
    }
}