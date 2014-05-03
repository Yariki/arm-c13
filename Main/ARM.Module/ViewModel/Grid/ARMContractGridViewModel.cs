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
    public class ARMContractGridViewModel : ARMGridViewModelBase<Contract>
    {
        public ARMContractGridViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMGridView view) 
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        public override string Title
        {
            get { return Resource.AppResource.Resources.Model_Contract_Title; }
        }

        protected override void UpdateRelatedSource()
        {
            base.UpdateRelatedSource();
            EventAggregator.GetEvent<ARMSyncEvent>().Publish(new ARMSyncEventPayload(eARMMetadata.Invoice));
            EventAggregator.GetEvent<ARMSyncEvent>().Publish(new ARMSyncEventPayload(eARMMetadata.Payment));
        }
    }
}