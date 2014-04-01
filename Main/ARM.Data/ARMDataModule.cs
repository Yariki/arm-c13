using ARM.Core.Module;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Data
{
    public class ARMDataModule : ARMBaseModule 
    {

        public ARMDataModule(IRegionManager regionManager, IUnityContainer unityContainer,
            IEventAggregator eventAggregator) 
            : base(regionManager,unityContainer,eventAggregator)
        {

		}

	}
}