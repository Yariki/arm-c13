using ARM.Core.Enums;
using ARM.Data.Models;
using ARM.Infrastructure.Events;
using ARM.Infrastructure.Events.EventPayload;
using ARM.Infrastructure.Interfaces.Grid;
using ARM.Infrastructure.MVVM;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.Grid
{
    /// <summary>
    /// Клас для відображення сітки з контрактами
    /// </summary>
    public class ARMContractGridViewModel : ARMGridViewModelBase<Contract>
    {
        /// <summary>
        /// Створити екземпляр <see cref="ARMContractGridViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="view">The view.</param>
        public ARMContractGridViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMGridView view) 
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        /// <summary>
        /// Заголовок вкладки.
        /// </summary>
        public override string Title
        {
            get { return Resource.AppResource.Resources.Model_Contract_Title; }
        }

        /// <summary>
        /// Викликається, коли потрібно оновити пов'язані об'єкти.
        /// </summary>
        protected override void UpdateRelatedSource()
        {
            base.UpdateRelatedSource();
            EventAggregator.GetEvent<ARMSyncEvent>().Publish(new ARMSyncEventPayload(eARMMetadata.Invoice));
            EventAggregator.GetEvent<ARMSyncEvent>().Publish(new ARMSyncEventPayload(eARMMetadata.Payment));
        }
    }
}