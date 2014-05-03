using System.Windows;

namespace ARM.Core.Extensions
{
    public static class ARMCommonExtensions
    {

        public static Visibility ToVisibility(this bool arg)
        {
            return arg ? Visibility.Visible : Visibility.Collapsed;
        }

        public static bool ToBool(this Visibility arg)
        {
            return arg == Visibility.Visible;
        }

    }
}