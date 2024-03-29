﻿using System;
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
    /// <summary>
    /// Клас для роботи з моделю даних - налаштування.
    /// </summary>
    public class ARMSettingsValidatableViewModel : ARMValidatableViewModelBase, IARMSettingsValidatableViewModel
    {
        /// <summary>
        /// Створити екземпляр <see cref="ARMSettingsValidatableViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="view">The view.</param>
        public ARMSettingsValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMSettingsView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        /// <summary>
        /// Заголовок вкладки.
        /// </summary>
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

        public string ContractPrefix
        {
            get { return Get(() => ContractPrefix); }
            set { Set(() => ContractPrefix, value); }
        }

        public string InvoicePrefix
        {
            get { return Get(() => InvoicePrefix); }
            set { Set(() => InvoicePrefix, value); }
        }

        public string PaymentPrefix
        {
            get { return Get(() => PaymentPrefix); }
            set { Set(() => PaymentPrefix, value); }
        }

        #endregion [properties]

        #region [emun resource]

        public IUnityContainer DiContainer
        {
            get { return UnityContainer; }
        }

        private Dictionary<EducationLevel, string> _sourceEducation;

        /// <summary>
        /// Отримує або задає список типів навчання.
        /// </summary>
        public Dictionary<EducationLevel, string> SourceEducation
        {
            get
            {
                return _sourceEducation ?? (_sourceEducation = ARMEnumHelper.Instance.GetLocalsForEnum<EducationLevel>());
            }
        }

        private Dictionary<InvoiceStatus, string> _sourceInvoice;

        /// <summary>
        /// Отримує або задає список типів рахунків.
        /// </summary>
        public Dictionary<InvoiceStatus, string> SourceInvoice
        {
            get { return _sourceInvoice ?? (_sourceInvoice = ARMEnumHelper.Instance.GetLocalsForEnum<InvoiceStatus>()); }
        }

        #endregion [emun resource]

        /// <summary>
        /// Виклик зберігання обєкту.
        /// </summary>
        /// <param name="arg">Аргумент.</param>
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