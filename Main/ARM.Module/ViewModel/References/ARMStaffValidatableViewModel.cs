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
    /// <summary>
    /// Клас для роботи з моделю даних - персонал.
    /// </summary>
    public class ARMStaffValidatableViewModel : ARMValidatableViewModelBase, IARMStaffValidatableViewModel
    {
        /// <summary>
        /// Створити екземпляр <see cref="ARMStaffValidatableViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="view">The view.</param>
        public ARMStaffValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMStaffView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        /// <summary>
        /// Заголовок вкладки.
        /// </summary>
        public override string Title
        {
            get
            {
                return FormatTitle(Resource.AppResource.Resources.Model_Data_Staff);
            }
        }

        #region [model properties]

        public string FirstName
        {
            get { return Get(() => FirstName); }
            set { Set(() => FirstName, value); }
        }

        public string MiddleName
        {
            get
            {
                return Get(() => MiddleName);
            }
            set
            {
                Set(() => MiddleName, value);
            }
        }

        public string LastName
        {
            get { return Get(() => LastName); }

            set
            {
                Set(() => LastName, value);
            }
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

        public StaffType StaffType
        {
            get { return Get(() => StaffType); }
            set { Set(() => StaffType, value); }
        }

        #endregion [model properties]

        #region [enum resources]

        private Dictionary<SexType, string> _sourceSex;

        /// <summary>
        /// Отримує список значень типу статі.
        /// </summary>
        public Dictionary<SexType, string> SourceSex
        {
            get { return _sourceSex ?? (_sourceSex = ARMEnumHelper.Instance.GetLocalsForEnum<SexType>()); }
        }

        private Dictionary<StaffType, string> _sourceStaff;

        /// <summary>
        /// Отримує або задає список значень типу персонала.
        /// </summary>
        public Dictionary<StaffType, string> SourceStaff
        {
            get { return _sourceStaff ?? (_sourceStaff = ARMEnumHelper.Instance.GetLocalsForEnum<StaffType>()); }
        }

        #endregion [enum resources]

        /// <summary>
        /// Виклик зберігання обєкту.
        /// </summary>
        /// <param name="arg">Аргумент.</param>
        protected override void SaveExecute(object arg)
        {
            ValidateBeforeSave();
            if (!IsValid)
                return;

            using (IUnitOfWork unitOfWork = UnityContainer.Resolve<IUnitOfWork>())
            {
                try
                {
                    var staffRepository = unitOfWork.StaffRepository;
                    switch (Mode)
                    {
                        case ViewMode.Add:
                            staffRepository.Insert(GetBusinessObject<Staff>());
                            break;

                        case ViewMode.Edit:
                            staffRepository.Update(GetBusinessObject<Staff>());
                            break;
                    }
                    staffRepository.Save();
                }
                catch (Exception ex)
                {
                    ARMSystemFacade.Instance.Logger.LogError(ex.Message);
                }
            }
            base.SaveExecute(arg);
        }
    }
}