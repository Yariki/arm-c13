using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Core.Module
{
    public abstract class ARMBaseModule : IModule
    {
        #region [needs]

        protected readonly IRegionManager RegionManager;
        protected readonly IUnityContainer UnityContainer;
        protected readonly IEventAggregator EventAggregator;

        #endregion [needs]

        protected ARMBaseModule(IRegionManager regionManager, IUnityContainer unityContainer,
            IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            RegionManager = regionManager;
            UnityContainer = unityContainer;
        }

        public void Initialize()
        {
            RegistreInterfaces();
            InjectViews();
            InternalInitialize();
        }

        protected virtual void RegistreInterfaces()
        {
        }

        protected virtual void InjectViews()
        {
        }

        protected virtual void InternalInitialize()
        {
        }
    }
}