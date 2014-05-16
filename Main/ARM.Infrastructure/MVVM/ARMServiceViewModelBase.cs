using ARM.Core.Interfaces;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Infrastructure.MVVM
{
    public abstract class ARMServiceViewModelBase : ARMWorkspaceViewModelBase
    {
        protected ARMServiceViewModelBase(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }
    }
}