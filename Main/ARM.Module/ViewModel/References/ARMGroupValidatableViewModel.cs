using System;
using ARM.Core.Enums;
using ARM.Data.Models;
using ARM.Data.UnitOfWork.Implementation;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.References.View;
using ARM.Module.Interfaces.References.ViewModel;
using ARM.Resource.AppResource;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.References
{
    public class ARMGroupValidatableViewModel : ARMValidatableViewModelBase, IARMGroupValidatableViewModel
    {
        public ARMGroupValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer,
            IEventAggregator eventAggregator, IARMGroupView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        #region IARMGroupValidatableViewModel Members

        public override string Title
        {
            get { return FormatTitle(Resources.Model_Data_Group); }
        }

        #endregion IARMGroupValidatableViewModel Members

        #region [properties]

        public IUnityContainer DiContainer
        {
            get { return UnityContainer; }
        }

        public string Name
        {
            get { return Get(() => Name); }
            set { Set(() => Name, value); }
        }

        public Guid FacultyId
        {
            get { return Get(() => FacultyId); }
            set { Set(() => FacultyId, value); }
        }

        public Guid? StaffId
        {
            get { return Get(() => StaffId); }
            set { Set(() => StaffId, value); }
        }

        #endregion [properties]

        protected override void SaveExecute(object arg)
        {
            if (!ValidateBeforeSave())
                return;
            try
            {
                using (var unitOfWork = UnityContainer.Resolve<IUnitOfWork>())
                {
                    switch (Mode)
                    {
                        case ViewMode.Add:
                            unitOfWork.GroupRepository.Insert(GetBusinessObject<Group>());
                            break;

                        case ViewMode.Edit:
                            unitOfWork.GroupRepository.Update(GetBusinessObject<Group>());
                            break;
                    }
                    unitOfWork.GroupRepository.Save();
                }
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }

            base.SaveExecute(arg);
        }
    }
}