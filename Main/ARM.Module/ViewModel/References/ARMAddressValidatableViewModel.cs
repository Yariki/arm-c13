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
    /// <summary>
    /// Клас для роботи з моделю даних - адреси.
    /// </summary>
    public class ARMAddressValidatableViewModel : ARMValidatableViewModelBase, IARMAddressValidatableViewModel
    {
        private IUnitOfWork _unitOfWork;

        /// <summary>
        /// Створити екземпляр <see cref="ARMAddressValidatableViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="view">The view.</param>
        public ARMAddressValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer,
            IEventAggregator eventAggregator, IARMAddressView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            _unitOfWork = UnityContainer.Resolve<IUnitOfWork>();
        }

        #region IARMAddressValidatableViewModel Members

        /// <summary>
        /// Заголовок вкладки.
        /// </summary>
        public override string Title
        {
            get { return FormatTitle(Resources.Model_Data_Address); }
        }

        #endregion IARMAddressValidatableViewModel Members

        #region [properties]

        public IUnityContainer DiContainer
        {
            get { return UnityContainer; }
        }

        public Guid CountryId
        {
            get { return Get(() => CountryId); }
            set { Set(() => CountryId, value); }
        }

        public string Region
        {
            get { return Get(() => Region); }
            set { Set(() => Region, value); }
        }

        public string City
        {
            get { return Get(() => City); }
            set { Set(() => City, value); }
        }

        public string Street
        {
            get { return Get(() => Street); }
            set { Set(() => Street, value); }
        }

        public string House
        {
            get { return Get(() => House); }
            set { Set(() => House, value); }
        }

        public string Apartment
        {
            get { return Get(() => Apartment); }
            set { Set(() => Apartment, value); }
        }

        #endregion [properties]

        #region [overrides]

        /// <summary>
        /// встановлення режиму роботи та моделі даних (у відповідності до метаданих та ідентифікатора)
        /// </summary>
        /// <param name="mode">Режим роботи.</param>
        /// <param name="metadata">Метадата.</param>
        /// <param name="id">Ідентифікатор.</param>
        /// <param name="isIdEmpty">Флаг, чи може фдентифікатор бути пустим.</param>
        public override void SetBusinessObject(ViewMode mode, eARMMetadata metadata, Guid id, bool isIdEmpty = false)
        {
            base.SetBusinessObject(mode, metadata, id, isIdEmpty);
            var entity = GetBusinessObject<Address>();
            if (entity == null || _unitOfWork == null)
                return;
            switch (Mode)
            {
                case ViewMode.Add:
                    entity.CountryId = _unitOfWork.SettingsRepository.GetDefaultCountry();
                    break;
            }
        }

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
                switch (Mode)
                {
                    case ViewMode.Add:
                        _unitOfWork.AddressRepository.Insert(GetBusinessObject<Address>());
                        break;

                    case ViewMode.Edit:
                        _unitOfWork.AddressRepository.Update(GetBusinessObject<Address>());
                        break;
                }
                _unitOfWork.AddressRepository.Save();
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }

            base.SaveExecute(arg);
        }

        /// <summary>
        /// Звільняє некеровані і - можливо - керовані ресурси.
        /// </summary>
        /// <param name="disposing"><c>true</c> щоб звільнити керовані і некеровані ресурси; <c>false</c> щоб звільнити тільки некеровані ресурси.</param>
        protected override void Dispose(bool disposing)
        {
            if (!Disposed && disposing)
            {
                if (_unitOfWork != null)
                {
                    _unitOfWork.Dispose();
                    _unitOfWork = null;
                }
            }
            base.Dispose(disposing);
        }

        #endregion [overrides]
    }
}