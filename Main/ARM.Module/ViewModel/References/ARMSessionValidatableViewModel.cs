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
    public class ARMSessionValidatableViewModel : ARMValidatableViewModelBase, IARMSessionValidatableViewModel
    {
        public ARMSessionValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer,
            IEventAggregator eventAggregator, IARMSessionView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        #region IARMSessionValidatableViewModel Members

        public override string Title
        {
            get { return FormatTitle(Resources.Model_Data_Session); }
        }

        #endregion IARMSessionValidatableViewModel Members

        #region [properties]

        public string Name
        {
            get { return Get(() => Name); }
            set { Set(() => Name, value); }
        }

        public DateTime DateBegin
        {
            get { return Get(() => DateBegin); }
            set { Set(() => DateBegin, value); }
        }

        public DateTime DateEnd
        {
            get { return Get(() => DateEnd); }
            set { Set(() => DateEnd, value); }
        }

        #endregion [properties]

        #region [override]

        public override void SetBusinessObject(ViewMode mode, eARMMetadata metadata, Guid id, bool isIdEmpty = false)
        {
            base.SetBusinessObject(mode, metadata, id, isIdEmpty);
            var entity = GetBusinessObject<Session>();
            if (entity == null)
                return;
            switch (Mode)
            {
                case ViewMode.Add:
                    entity.DateBegin = entity.DateEnd = DateTime.Now;
                    break;
            }
        }

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
                            unitOfWork.SessionRepository.Insert(GetBusinessObject<Session>());
                            break;

                        case ViewMode.Edit:
                            unitOfWork.SessionRepository.Update(GetBusinessObject<Session>());
                            break;
                    }
                    unitOfWork.SessionRepository.Save();
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