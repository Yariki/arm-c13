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
    /// Клас для роботи з моделю даних - заняття.
    /// </summary>
    public class ARMClassValidatableViewModel : ARMValidatableViewModelBase, IARMClassValidatableViewModel
    {
        /// <summary>
        /// Створити екземпляр <see cref="ARMClassValidatableViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="view">The view.</param>
        public ARMClassValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer,
            IEventAggregator eventAggregator, IARMClassView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        #region IARMClassValidatableViewModel Members

        /// <summary>
        /// Заголовок вкладки.
        /// </summary>
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

        public eARMClassSummary Summary
        {
            get { return Get(() => Summary); }
            set { Set(() => Summary, value); }
        }

        public bool CourseWorkPresent
        {
            get { return Get(() => CourseWorkPresent); }
            set { Set(() => CourseWorkPresent, value); }
        }

        #endregion [properties]

        #region [enum source]

        private Dictionary<eARMClassSummary, string> _sourceClassSummary;
        /// <summary>
        /// Отримує або задає даня длі типів оцінування класів.
        /// </summary>
        public Dictionary<eARMClassSummary, string> SourceClassSummary
        {
            get { return _sourceClassSummary ?? (_sourceClassSummary = ARMEnumHelper.Instance.GetLocalsForEnum<eARMClassSummary>()); }
        }

        #endregion


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
                UnitOfWork = UnityContainer.Resolve<IUnitOfWork>();
                switch (Mode)
                {
                    case ViewMode.Add:
                        UnitOfWork.ClassRepository.Insert(GetBusinessObject<Class>());
                        break;

                    case ViewMode.Edit:
                        UnitOfWork.ClassRepository.Update(GetBusinessObject<Class>());
                        break;
                }
                UnitOfWork.ClassRepository.Save();
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