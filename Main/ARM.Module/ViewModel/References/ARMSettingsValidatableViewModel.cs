using System;
using System.Collections.Generic;
using ARM.Core.Enums;
using ARM.Data.Models;
using ARM.Data.UnitOfWork.Implementation;
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
    public class ARMSettingsValidatableViewModel : ARMValidatableViewModelBase, IARMSettingsValidatableViewModel
    {
        public ARMSettingsValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMSettingsView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        public override string Title
        {
            get { return Resource.AppResource.Resources.Model_Settings_Title; }
        }

        #region [properties]

        public Guid DefUniversity
        {
            get { return Get(() => DefUniversity); }
            set { Set(() => DefUniversity, value); }
        }

        public Guid DefCountry
        {
            get { return Get(() => DefUniversity); }
            set { Set(() => DefCountry, value); }
        }

        public EducationLevel DefEducationLevel
        {
            get { return Get(() => DefEducationLevel); }
            set { Set(() => DefEducationLevel, value); }
        }

        public InvoiceStatus DefInvoiceStatus
        {
            get { return Get(() => DefInvoiceStatus); }
            set { Set(() => DefInvoiceStatus, value); }
        }

        public decimal DefBaseStipend
        {
            get { return Get(() => DefBaseStipend); }
            set { Set(() => DefBaseStipend, value); }
        }

        public decimal DefIncreaseStipend
        {
            get { return Get(() => DefIncreaseStipend); }
            set { Set(() => DefIncreaseStipend, value); }
        }

        public double DefStipendMark
        {
            get { return Get(() => DefStipendMark); }
            set { Set(() => DefStipendMark, value); }
        }

        public double DefStipenHighMark
        {
            get { return Get(() => DefStipenHighMark); }
            set { Set(() => DefStipenHighMark, value); }
        }

        #endregion [properties]

        #region [emun resource]

        public IUnityContainer DiContainer
        {
            get { return UnityContainer; }
        }

        private Dictionary<EducationLevel, string> _sourceEducation;

        public Dictionary<EducationLevel, string> SourceEducation
        {
            get
            {
                return _sourceEducation ?? (_sourceEducation = EnumHelper.Instance.GetLocalsForEnum<EducationLevel>());
            }
        }

        private Dictionary<InvoiceStatus, string> _sourceInvoice;

        public Dictionary<InvoiceStatus, string> SourceInvoice
        {
            get { return _sourceInvoice ?? (_sourceInvoice = EnumHelper.Instance.GetLocalsForEnum<InvoiceStatus>()); }
        }

        #endregion [emun resource]

        protected override void SaveExecute(object arg)
        {
            ValidateBeforeSave();
            if (!IsValid)
                return;
            try
            {
                using (IUnitOfWork unitOfWork = UnityContainer.Resolve<IUnitOfWork>())
                {
                    var settingsRep = unitOfWork.SettingsRepository;
                    switch (Mode)
                    {
                        case ViewMode.Edit:
                            settingsRep.Update(GetBusinessObject<SettingParameters>());
                            settingsRep.Save();
                            break;
                    }
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