///////////////////////////////////////////////////////////
//  InfrastructureModule.cs
//  Implementation of the Class InfrastructureModule
//  Generated by Enterprise Architect
//  Created on:      31-Mar-2014 11:50:15 PM
///////////////////////////////////////////////////////////


using ARM.Core.Interfaces;
using ARM.Core.Module;
using ARM.Infrastructure.MVVM.View;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Infrastructure {
	public class InfrastructureModule : ARMBaseModule 
    {

        public InfrastructureModule(IRegionManager regionManager, IUnityContainer unityContainer,
            IEventAggregator eventAggregator) 
            : base(regionManager,unityContainer,eventAggregator)
        {

		}

	    protected override void RegistreInterfaces()
	    {
	        base.RegistreInterfaces();
	        UnityContainer.RegisterType<IARMToolboxView, ARMToolboxView>();
	    }
    }//end InfrastructureModule

}//end namespace ARM.Infrastructure