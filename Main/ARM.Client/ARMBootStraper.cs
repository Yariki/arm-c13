using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
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

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var catalog = new ModuleCatalog();
            catalog.AddModule(typeof(ARM.Module.MainModule));
            return catalog;
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            var catalog = this.ModuleCatalog;
        }
    }
}