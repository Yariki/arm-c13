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
    public class ARMSpecialityValidatableViewModel : ARMValidatableViewModelBase, IARMSpecialityValidatableViewModel
    {
        public ARMSpecialityValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer,
            IEventAggregator eventAggregator, IARMSpecialityView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        #region IARMSpecialityValidatableViewModel Members

        public override string Title
        {
            get { return FormatTitle(Resources.Model_Data_Speciality); }
        }

        #endregion IARMSpecialityValidatableViewModel Members

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

        public Guid? FacultyId
        {
            get { return Get(() => FacultyId); }
            set { Set(() => FacultyId, value); }
        }

        #endregion [properties]

        #region [override]

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
                            unitOfWork.SpeciltyRepository.Insert(GetBusinessObject<Specialty>());
                            break;

                        case ViewMode.Edit:
                            unitOfWork.SpeciltyRepository.Update(GetBusinessObject<Specialty>());
                            break;
                    }
                    unitOfWork.SpeciltyRepository.Save();
                }
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }
            base.SaveExecute(arg);
        }

        #endregion [override]
    }
}