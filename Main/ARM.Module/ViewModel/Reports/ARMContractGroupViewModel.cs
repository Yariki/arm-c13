using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.Reports.View;
using ARM.Module.Interfaces.Reports.ViewModel;
using ManagedExcel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Xceed.Wpf.DataGrid;
using Group = ARM.Data.Models.Group;

namespace ARM.Module.ViewModel.Reports
{
    public class ARMContractGroupViewModel : ARMReportViewModelBase, IARMContractGroupViewModel
    {
        public ARMContractGroupViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMContractGroupView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        public override string Title
        {
            get { return Resource.AppResource.Resources.Report_ContractGroup_Title; }
        }

        #region [properties]

        public ObservableCollection<Group> Groups
        {
            get { return Get(() => Groups); }
            set { Set(() => Groups, value); }
        }

        public Group SelectedGroup
        {
            get { return Get(() => SelectedGroup); }
            set
            {
                Set(() => SelectedGroup, value);
                SelectedGroupChanged();
            }
        }

        public ObservableCollection<Contract> Contracts
        {
            get { return Get(() => Contracts); }
            set { Set(() => Contracts, value); }
        }


        #endregion

        #region [overrides]

        public override void Initialize()
        {
            base.Initialize();
            Groups = new ObservableCollection<Group>(UnitOfWork.GroupRepository.GetAll());
            Contracts = new ObservableCollection<Contract>();
        }

        protected override bool CanExportExecute(object arg)
        {
            return Contracts != null && Contracts.Any();
        }

        protected override int GenerateHeaders(Worksheet sheet)
        {
            int row = 1;

            SheetManipulator.SetSheetCellWidth(sheet, row, 1, 25);
            SheetManipulator.SetSheetCellWidth(sheet, row, 2, 25);
            SheetManipulator.SetSheetCellWidth(sheet, row, 3, 25);
            SheetManipulator.SetSheetCellWidth(sheet, row, 4, 25);
            SheetManipulator.SetSheetCellWidth(sheet, row, 5, 25);
            SheetManipulator.SetSheetCellWidth(sheet, row, 6, 25);

            SheetManipulator.SetSheetCellValue(sheet, row, 1, Resource.AppResource.Resources.Model_Name);
            SheetManipulator.SetSheetCellValue(sheet, row, 2, Resource.AppResource.Resources.Model_Contract_Number);
            SheetManipulator.SetSheetCellValue(sheet, row, 3, Resource.AppResource.Resources.Model_Contract_EducationLevel);
            SheetManipulator.SetSheetCellValue(sheet, row, 4, Resource.AppResource.Resources.Model_Contract_Parent);
            SheetManipulator.SetSheetCellValue(sheet, row, 5, Resource.AppResource.Resources.Model_Contract_Student);
            SheetManipulator.SetSheetCellValue(sheet, row, 6, Resource.AppResource.Resources.Model_Contract_Price);
            return ++row;
        }

        protected override void FillSheet(Worksheet sheet, int rowStart)
        {
            int current = 0;
            int row = rowStart;
            foreach (var contract in Contracts)
            {
                SheetManipulator.SetSheetCellValue(sheet, row, 1, contract.Name);
                SheetManipulator.SetSheetCellValue(sheet, row, 2, contract.Number);
                SheetManipulator.SetSheetCellValue(sheet, row, 3, contract.Level.ToString());
                SheetManipulator.SetSheetCellValue(sheet, row, 4, contract.Customer.Display);
                SheetManipulator.SetSheetCellValue(sheet, row, 5, contract.Student.Display);
                SheetManipulator.SetSheetCellValue(sheet, row, 6, contract.Price);
                row++;
                current++;
                UpdateProgress(current,Contracts.Count);
            }
        }

        #endregion

        #region [private]

        private void SelectedGroupChanged()
        {
            if (SelectedGroup == null)
                return;
            var listId = SelectedGroup.Students.Where(s => s.StudyType == eARMStudyType.Contract).Select(s => s.Id);
            var listContracts =
                UnitOfWork.ContractRepository.GetAllWithRelated().Where(c => listId.Contains(c.StudentId.Value));
            Contracts.Clear();
            Contracts = listContracts.Any() ? new ObservableCollection<Contract>(listContracts) : null;
            OnPropertyChanged(() => Contracts);
        }

        #endregion
    }
}