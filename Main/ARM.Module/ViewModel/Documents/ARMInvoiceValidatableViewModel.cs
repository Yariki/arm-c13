using System;
using System.Collections.Generic;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Data.UnitOfWork.Implementation;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.Helpers;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.Documents.View;
using ARM.Module.Interfaces.Documents.ViewModel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.Documents
{
    /// <summary>
    /// Клас для роботи з рахунками.
    /// </summary>
    public class ARMInvoiceValidatableViewModel : ARMValidatableViewModelBase, IARMInvoiceValidatableViewModel
    {
        private IUnitOfWork _unitOfWork = null;

        /// <summary>
        /// Створити екземпляр <see cref="ARMInvoiceValidatableViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">Менеджер регіонів.</param>
        /// <param name="unityContainer">Контейнер.</param>
        /// <param name="eventAggregator">Агрегатор подій.</param>
        /// <param name="view">Представлення.</param>
        public ARMInvoiceValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMInvoiceView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            _unitOfWork = UnityContainer.Resolve<IUnitOfWork>();
        }

        /// <summary>
        /// Заголовок вкладки.
        /// </summary>
        public override string Title
        {
            get { return FormatTitle(Resource.AppResource.Resources.Model_Data_Invoice); }
        }

        #region [proprties]

        public IUnityContainer DiContainer
        {
            get { return UnityContainer; }
        }

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

        public Guid ContractId
        {
            get { return Get(() => ContractId); }
            set { Set(() => ContractId, value); }
        }

        public Guid? SessionId
        {
            get { return Get(() => SessionId); }
            set { Set(() => SessionId, value); }
        }

        public decimal Price
        {
            get { return Get(() => Price); }
            set { Set(() => Price, value); }
        }

        public DateTime DateDue
        {
            get { return Get(() => DateDue); }
            set { Set(() => DateDue, value); }
        }

        public InvoiceStatus Status
        {
            get { return Get(() => Status); }
            set { Set(() => Status, value); }
        }

        #endregion

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
            var entity = GetBusinessObject<Invoice>();
            if (entity == null || _unitOfWork == null)
                return;
            switch (Mode)
            {
                case ViewMode.Add:
                    entity.Status = _unitOfWork.SettingsRepository.GetDefaultInvoiceStatus();
                    entity.DateDue = DateTime.Now.Date.AddDays(30); //30 - could be in settings
                    entity.Number = string.Format("{0}-{1:D10}", _unitOfWork.SettingsRepository.GetInvoicePrefix(),
                        _unitOfWork.SettingsRepository.GetNextInvoiceNumber());
                    break;
            }
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

        /// <summary>
        /// Виклик зберігання обєкту.
        /// </summary>
        /// <param name="arg">Аргумент.</param>
        protected override void SaveExecute(object arg)
        {
            if (!ValidateBeforeSave() || _unitOfWork == null)
                return;

            try
            {
                switch (Mode)
                {

                    case ViewMode.Add:
                        _unitOfWork.InvoiseRepository.Insert(GetBusinessObject<Invoice>());
                        break;
                    case ViewMode.Edit:
                        _unitOfWork.InvoiseRepository.Update(GetBusinessObject<Invoice>());
                        break;
                }
                _unitOfWork.InvoiseRepository.Save();
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }

            base.SaveExecute(arg);
        }

        #endregion

        #region [enum source]
        
        private Dictionary<InvoiceStatus, string> _sourceInvoice;
        /// <summary>
        /// Отримує або задає дані для типів рахунків.
        /// </summary>
        public Dictionary<InvoiceStatus, string> SourceInvoice
        {
            get { return _sourceInvoice ?? (_sourceInvoice = ARMEnumHelper.Instance.GetLocalsForEnum<InvoiceStatus>()); }
        }

        #endregion

        #region [private]
        #endregion
    }
}