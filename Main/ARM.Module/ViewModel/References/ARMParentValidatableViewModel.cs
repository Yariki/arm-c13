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
using ARM.Resource.AppResource;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.References
{
    /// <summary>
    /// Клас для роботи з моделю даних - батьки.
    /// </summary>
    public class ARMParentValidatableViewModel : ARMValidatableViewModelBase, IARMParentValidatableViewModel
    {
        private Dictionary<SexType, string> _sourceSex;

        /// <summary>
        /// Створити екземпляр <see cref="ARMParentValidatableViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="view">The view.</param>
        public ARMParentValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer,
            IEventAggregator eventAggregator, IARMParentView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        /// <summary>
        /// Отримує або задає список типів для статі.
        /// </summary>
        public Dictionary<SexType, string> SourceSex
        {
            get { return _sourceSex ?? (_sourceSex = ARMEnumHelper.Instance.GetLocalsForEnum<SexType>()); }
        }

        #region [override]

        /// <summary>
        /// Виклик зберігання обєкту.
        /// </summary>
        /// <param name="arg">Аргумент.</param>
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
                            unitOfWork.ParentRepository.Insert(GetBusinessObject<Parent>());
                            break;

                        case ViewMode.Edit:
                            unitOfWork.ParentRepository.Update(GetBusinessObject<Parent>());
                            break;
                    }
                    unitOfWork.ParentRepository.Save();
                }
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }
            base.SaveExecute(arg);
        }

        #endregion [override]

        #region IARMParentValidatableViewModel Members

        /// <summary>
        /// Заголовок вкладки.
        /// </summary>
        public override string Title
        {
            get { return FormatTitle(Resources.Model_Data_Parent); }
        }

        #endregion IARMParentValidatableViewModel Members

        #region [properties]

        public IUnityContainer DiContainer
        {
            get { return UnityContainer; }
        }

        public string FirstName
        {
            get { return Get(() => FirstName); }
            set { Set(() => FirstName, value); }
        }

        public string MiddleName
        {
            get { return Get(() => MiddleName); }
            set { Set(() => MiddleName, value); }
        }

        public string LastName
        {
            get { return Get(() => LastName); }
            set { Set(() => LastName, value); }
        }

        public string Email
        {
            get { return Get(() => Email); }
            set { Set(() => Email, value); }
        }

        public string PhoneMobile
        {
            get { return Get(() => PhoneMobile); }
            set { Set(() => PhoneMobile, value); }
        }

        public string PhoneHome
        {
            get { return Get(() => PhoneHome); }
            set { Set(() => PhoneHome, value); }
        }

        public SexType Sex
        {
            get { return Get(() => Sex); }
            set { Set(() => Sex, value); }
        }

        public Guid? StudentId
        {
            get { return Get(() => StudentId); }
            set { Set(() => StudentId, value); }
        }

        public Guid AddressId
        {
            get { return Get(() => AddressId); }
            set { Set(() => AddressId, value); }
        }

        #endregion [properties]
    }
}