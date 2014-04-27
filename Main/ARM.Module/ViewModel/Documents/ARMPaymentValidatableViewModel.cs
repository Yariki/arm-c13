using System;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Data.UnitOfWork.Implementation;
using ARM.Infrastructure.Events;
using ARM.Infrastructure.Events.EventPayload;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.Documents.View;
using ARM.Module.Interfaces.Documents.ViewModel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.Documents
{
    public class ARMPaymentValidatableViewModel : ARMValidatableViewModelBase, IARMPaymentValidatableViewModel
    {
        private IUnitOfWork _unitOfWork = null;

        public ARMPaymentValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMPaymentView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            _unitOfWork = UnityContainer.Resolve<IUnitOfWork>();
        }

        public override string Title
        {
            get { return FormatTitle(Resource.AppResource.Resources.Model_Data_Payment); }
        }

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

        public string Number
        {
            get { return Get(() => Number); }
            set { Set(() => Number, value); }
        }

        public Guid InvoiceId
        {
            get { return Get(() => InvoiceId); }
            set
            {
                Set(() => InvoiceId, value);
                OnInvoiceChanged();
            }
        }

        public DateTime Date
        {
            get { return Get(() => Date); }
            set { Set(() => Date, value); }
        }

        public decimal Sum
        {
            get { return Get(() => Sum); }
            set { Set(() => Sum, value); }
        }

        #endregion

        #region [overrides]

        public override void SetBusinessObject(ViewMode mode, eARMMetadata metadata, Guid id, bool isIdEmpty = false)
        {
            base.SetBusinessObject(mode, metadata, id, isIdEmpty);
            var entity = GetBusinessObject<Payment>();
            if (entity == null || _unitOfWork == null)
                return;
            switch (Mode)
            {
                case ViewMode.Add:
                    entity.Date = DateTime.Now.Date;
                    break;
            }
        }

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

        protected override void SaveExecute(object arg)
        {
            if (!ValidateBeforeSave() || _unitOfWork == null)
                return;
            try
            {
                switch (Mode)
                {
                    case ViewMode.Add:
                        var entity = GetBusinessObject<Payment>();
                        _unitOfWork.PaymentRepository.Insert(entity);
                        var invoice = _unitOfWork.InvoiseRepository.GetById(entity.InvoiceId);
                        if (invoice != null)
                        {
                            invoice.Status = InvoiceStatus.PaidUp;
                            _unitOfWork.InvoiseRepository.Update(invoice);
                        }
                        break;
                    case ViewMode.Edit:
                        _unitOfWork.PaymentRepository.Update(GetBusinessObject<Payment>());
                        break;
                }
                _unitOfWork.PaymentRepository.Save();
                _unitOfWork.InvoiseRepository.Save();
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }
            EventAggregator.GetEvent<ARMSyncEvent>().Publish(new ARMSyncEventPayload(eARMMetadata.Invoice));
            base.SaveExecute(arg);
        }

        #endregion

        #region [private]

        private void OnInvoiceChanged()
        {
            if (InvoiceId == Guid.Empty || _unitOfWork == null)
                return;
            var invoice = _unitOfWork.InvoiseRepository.GetById(InvoiceId);
            if (invoice != null)
            {
                Sum = invoice.Price;
            }
        }

        #endregion
    }
}