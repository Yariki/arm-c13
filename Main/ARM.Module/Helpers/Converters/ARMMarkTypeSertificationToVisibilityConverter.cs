using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using ARM.Data.Models;

namespace ARM.Module.Helpers.Converters
{
    /// <summary>
    /// Конвертор типу оцінки у видимість
    /// </summary>
    public class ARMMarkTypeSertificationToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Конвертує значення
        /// </summary>
        /// <param name="value">Значення привязки</param>
        /// <param name="targetType">Тип значення.</param>
        /// <param name="parameter">Допоміжний параметер для конвертування.</param>
        /// <param name="culture">Поточна культура.</param>
        /// <returns>
        /// Сконвертоване значення
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (MarkType) value;


            return !IsInverted ? type != MarkType.Certification ? Visibility.Visible : Visibility.Collapsed :
                type == MarkType.Certification ? Visibility.Visible : Visibility.Collapsed;
        }
        /// <summary>
        /// Конвертація в зворотному напряму (не використовується в нашому випадку).
        /// </summary>
        /// <param name="value">Значення привязки</param>
        /// <param name="targetType">Тип значення.</param>
        /// <param name="parameter">Допоміжний параметер для конвертування.</param>
        /// <param name="culture">Поточна культура.</param>
        /// <returns>
        /// Сконвертоване значення
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return MarkType.None;
        }

        /// <summary>
        /// Чи буде значення інвертуватись.
        /// </summary>
        public bool IsInverted { get; set; }

    }
}