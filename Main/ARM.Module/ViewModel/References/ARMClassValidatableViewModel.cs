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
    public class ARMClassValidatableViewModel : ARMValidatableViewModelBase, IARMClassValidatableViewModel
    {
        public ARMClassValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer,
            IEventAggregator eventAggregator, IARMClassView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        #region IARMClassValidatableViewModel Members

        public override string Title
        {
            get { return FormatTitle(Resources.Model_Data_Class); }
        }

        #endregion IARMClassValidatableViewModel Members

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

        public Guid StaffId
        {
            get { return Get(() => StaffId); }
            set { Set(() => StaffId, value); }
        }

        public Guid SessionId
        {
            get { return Get(() => SessionId); }
            set { Set(() => SessionId, value); }
        }

        #endregion [properties]

        #region [override]

        protected override void SaveExecute(object arg)
        {
            if (!ValidateBeforeSave())
                return;
            IUnitOfWork unitOfWork = null;
            try
            {
                unitOfWork = UnityContainer.Resolve<IUnitOfWork>();
                switch (Mode)
                {
                    case ViewMode.Add:
                        unitOfWork.ClassRepository.Insert(GetBusinessObject<Class>());
                        break;

                    case ViewMode.Edit:
                        unitOfWork.ClassRepository.Update(GetBusinessObject<Class>());
                        break;
                }
                unitOfWork.ClassRepository.Save();
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }
            finally
            {
                if (unitOfWork != null)
                    unitOfWork.Dispose();
            }

            base.SaveExecute(arg);
        }

        #endregion [override]
    }
}