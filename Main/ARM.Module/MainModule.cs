///////////////////////////////////////////////////////////
//  MainModule.cs
//  Implementation of the Class MainModule
//  Generated by Enterprise Architect
//  Created on:      31-Mar-2014 11:50:26 PM
///////////////////////////////////////////////////////////

using ARM.Core.Interfaces;
using ARM.Core.Module;
using ARM.Infrastructure.Interfaces.Grid;
using ARM.Infrastructure.Region;
using ARM.Module.Interfaces;
using ARM.Module.Interfaces.References.View;
using ARM.Module.Interfaces.References.ViewModel;
using ARM.Module.Interfaces.View;
using ARM.Module.View.Grid;
using ARM.Module.View.Main;
using ARM.Module.View.References;
using ARM.Module.ViewModel.Main;
using ARM.Module.ViewModel.References;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Unity.AutoRegistration;

namespace ARM.Module
{
    public class MainModule : ARMBaseModule
    {
        public MainModule(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator)
            : base(regionManager, unityContainer, eventAggregator)
        {
        }

        protected override void RegistreInterfaces()
        {
            base.RegistreInterfaces();
            //registre view
            UnityContainer.RegisterType<IARMMainWorkspaceView, ARMMainWorkspaceView>();
            UnityContainer.RegisterType<IARMMainMenuView, ARMMenuView>();
            UnityContainer.RegisterType<IARMMainStatusBarView, ARMStatusBarView>();
            UnityContainer.RegisterType<IARMMainToolboxView, ARMToolboxView>();
            //register view model
            UnityContainer.RegisterType<IARMMainWorkspaceViewModel, ARMMainWorkspaceViewModel>(new ContainerControlledLifetimeManager());
            UnityContainer.RegisterType<IARMMainMenuViewModel, ARMMainMenuViewModel>();
            UnityContainer.RegisterType<IARMMainStatusBarViewModel, ARMMainStatusBarViewModel>();
            UnityContainer.RegisterType<IARMMainToolboxViewModel, ARMMainToolboxViewModel>();

            //additional
            UnityContainer.RegisterType<IARMGridView, ARMGridView>();
            UnityContainer.RegisterType<IARMUniversityDataViewModel, ARMUniversityDataViewModel>();
            UnityContainer.RegisterType<IARMUniversityView, ARMUniversityView>();

            UnityContainer.RegisterType<IARMStaffView, ARMStaffView>();
            UnityContainer.RegisterType<IARMStaffValidatableViewModel, ARMStaffValidatableViewModel>();

            UnityContainer.RegisterType<IARMLanguageView, ARMLanguageView>();
            UnityContainer.RegisterType<IARMLanguageValidatableViewModel, ARMLanguageValidatableViewModel>();

            UnityContainer.RegisterType<IARMCountryView, ARMCountryView>();
            UnityContainer.RegisterType<IARMCountryValidatableViewModel, ARMCountryValidatableViewModel>();

            UnityContainer.ConfigureAutoRegistration()
                .ExcludeSystemAssemblies()
                //.Include(If.ImplementsITypeName,Then.Register().UsingPerCallMode())
                .Include(type => type.ImplementsOpenGeneric(typeof(IARMGridViewModel<>)), Then.Register().UsingPerCallMode())
                    .ApplyAutoRegistration();
        }

        protected override void InjectViews()
        {
            base.InjectViews();
            IARMMainWorkspaceViewModel mainViewModel = UnityContainer.Resolve<IARMMainWorkspaceViewModel>();
            IRegion region = RegionManager.Regions[ARMMainRegionNames.WORKSPACE_REGION];
            region.Add(mainViewModel.View);
            region = RegionManager.Regions[ARMMainRegionNames.MENU_REGION];
            region.Add(mainViewModel.MenuView);
            region = RegionManager.Regions[ARMMainRegionNames.STATUSBAR_REGION];
            region.Add(mainViewModel.StatusBarView);
            region = RegionManager.Regions[ARMMainRegionNames.TOOLBOX_REGION];
            region.Add(mainViewModel.ToolboxView);
        }
    }//end MainModule
}//end namespace ARM.Module