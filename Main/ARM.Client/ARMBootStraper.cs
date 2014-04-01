using System.Windows;
using Microsoft.Practices.Prism.UnityExtensions;

namespace ARM.Client
{
    public class ARMBootStraper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return null;
        }

    }
}