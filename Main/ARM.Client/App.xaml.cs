using System.Windows;

namespace ARM.Client
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var bootStrap = new ARMBootStraper();
            bootStrap.Run();
        }
    }
}