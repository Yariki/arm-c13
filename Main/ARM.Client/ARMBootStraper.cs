using System;
using System.Windows;
using ARM.Core.Enums;
using ARM.Data.Models;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.Region;
using ARM.Module.Interfaces;
using ARM.Module.Interfaces.Login.ViewModel;
using ARM.Module.View.Login.Dialog;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.UnityExtensions.Properties;
using Microsoft.Practices.Unity;

namespace ARM.Client
{
    public class ARMBootStraper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            MainWindow mainWindow = Container.Resolve<MainWindow>();
            return mainWindow;
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var catalog = new ModuleCatalog();
            catalog.AddModule(typeof(ARM.Data.ARMDataModule));
            catalog.AddModule(typeof(ARM.Core.CoreModule));
            catalog.AddModule(typeof(ARM.Infrastructure.InfrastructureModule));
            catalog.AddModule(typeof(ARM.Module.MainModule));
            return catalog;
        }


        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            var catalog = this.ModuleCatalog;
        }

        public override void Run(bool runWithDefaultConfiguration)
        {
            base.Run(runWithDefaultConfiguration);
            Login();
        }

        private void Login()
        {
            var loginViewModel = Container.Resolve<IARMLoginViewModel>();
            loginViewModel.SetBusinessObject(ViewMode.Add,eARMMetadata.Login,new Login());
            var dlg = new ARMLoginDialogView(loginViewModel){Width = 250, Height = 200};
            var result = dlg.ShowDialog();
            if (result.HasValue && result.Value && loginViewModel.IsUserValid)
            {
                switch (loginViewModel.Language)
                {
                    case eARMSystemLanguage.English:
                        System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                        break;
                    case eARMSystemLanguage.Ukrainian:
                        System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("uk");
                        break;
                }
                ARMSystemFacade.Instance.CurrentUser = loginViewModel.GetUser();
                ShowMainUi();
            }
            else
            {
                App.Current.Shutdown(0);
            }
        }

        private void ShowMainUi()
        {
            App.Current.MainWindow = (Window)this.Shell;
            IARMMainWorkspaceViewModel workSpaceModel = Container.Resolve<IARMMainWorkspaceViewModel>();
            if (workSpaceModel != null)
            {
                (this.Shell as IMainWindow).Model = workSpaceModel;
            }
            var regionManager = Container.Resolve<IRegionManager>();
            IRegion region = regionManager.Regions[ARMMainRegionNames.WORKSPACE_REGION];

            region.Add(workSpaceModel.View);
            region = regionManager.Regions[ARMMainRegionNames.MENU_REGION];
            region.Add(workSpaceModel.MenuView);
            region = regionManager.Regions[ARMMainRegionNames.STATUSBAR_REGION];
            region.Add(workSpaceModel.StatusBarView);
            region = regionManager.Regions[ARMMainRegionNames.TOOLBOX_REGION];
            region.Add(workSpaceModel.ToolboxView);

            if (App.Current.MainWindow != null)
            {
                App.Current.MainWindow.Show();
            }
        }
    }
}