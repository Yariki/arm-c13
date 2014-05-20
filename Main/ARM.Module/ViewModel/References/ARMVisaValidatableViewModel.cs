using System;
using System.Collections.Generic;
using System.Windows.Input;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.Helpers;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.References.View;
using ARM.Module.Interfaces.References.ViewModel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.References
{
    public class ARMVisaValidatableViewModel : ARMValidatableViewModelBase, IARMVisaValidatableViewModel
    {
        public ARMVisaValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMVisaView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            OkCommand = new ARMRelayCommand(OkExecute, CanOkExecute);
        }

        public override string Title
        {
            get { return FormatTitle(Resource.AppResource.Resources.Model_Data_Visa); }
        }

        #region [properties]

        public string Name
        {
            get { return Get(() => Name); }
            set { Set(() => Name, value); }
        }

        public string Number
        {
            get { return Get(() => Number); }
            set { Set(() => Number, value); }
        }

        public string PlaceOfIssue
        {
            get { return Get(() => PlaceOfIssue); }
            set { Set(() => PlaceOfIssue, value); }
        }

        public VisaType VisaType
        {
            get { return Get(() => VisaType); }
            set { Set(() => VisaType, value); }
        }

        public string PassportNumber
        {
            get { return Get(() => PassportNumber); }
            set { Set(() => PassportNumber, value); }
        }

        public DateTime ValidFrom
        {
            get { return Get(() => ValidFrom); }
            set { Set(() => ValidFrom, value); }
        }

        public DateTime ValidUntil
        {
            get { return Get(() => ValidUntil); }
            set { Set(() => ValidUntil, value); }
        }



        #endregion

        #region [enum source]

        private Dictionary<VisaType, string> _sourceVisaType;

        public Dictionary<VisaType, string> SourceVisaType
        {
            get { return _sourceVisaType ?? (_sourceVisaType = ARMEnumHelper.Instance.GetLocalsForEnum<VisaType>()); }
        }

        #endregion

        #region [overrides]

        public override void SetBusinessObject(ViewMode mode, eARMMetadata metadata, Guid id, bool isIdEmpty = false)
        {
            base.SetBusinessObject(mode, metadata, id, isIdEmpty);
            var entity = GetBusinessObject<Visa>();
            if (entity == null)
                return;
            switch (Mode)
            {

                case ViewMode.Add:
                    entity.ValidFrom = entity.ValidUntil = DateTime.Now.Date;
                    break;
            }
        }


        #endregion

        #region [private]

        private void OkExecute(object arg)
        {

        }

        private bool CanOkExecute(object arg)
        {
            return true;
        }

        #endregion

        public ICommand OkCommand { get; private set; }
        public bool Validate()
        {
            return ValidateBeforeSave();
        }
    }
}