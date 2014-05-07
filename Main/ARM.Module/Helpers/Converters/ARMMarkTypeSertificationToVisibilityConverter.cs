using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using ARM.Data.Models;

namespace ARM.Module.Helpers.Converters
{
    public class ARMMarkTypeSertificationToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (MarkType) value;


            return !IsInverted ? type != MarkType.Certification ? Visibility.Visible : Visibility.Collapsed :
                type == MarkType.Certification ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return MarkType.None;
        }

        public bool IsInverted { get; set; }

    }
}