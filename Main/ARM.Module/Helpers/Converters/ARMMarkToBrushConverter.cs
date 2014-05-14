using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ARM.Module.Helpers.Converters
{
    /// <summary>
    /// конвертер значення оцінки до кольору. Для зручності відображення на користувацькому інтерфейсі.
    /// </summary>
    public class ARMMarkToBrushConverter : IValueConverter
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
            var mark = (decimal)value;
            return (mark >= decimal.Zero && mark < 3)
                ? (object) Brushes.OrangeRed
                : (mark >= 3 && mark < 4)
                    ? (object) Brushes.Orange
                    : (mark >= 4 && mark < 5)
                        ? (object) Brushes.Yellow
                        : (mark == 5) ? (object) Brushes.LightGreen : Brushes.Transparent;
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
            throw new NotImplementedException();
        }
    }
}