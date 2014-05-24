using System.Windows;

namespace ARM.Core.Extensions
{
    /// <summary>
    /// статичний класс, який є контейнером для загальних методів розширення
    /// </summary>
    public static class ARMCommonExtensions
    {
        /// <summary>
        /// метод розширення для конвертації bool значення у Visibility
        /// </summary>
        /// <param name="arg">значення для конвертації</param>
        /// <returns></returns>
        public static Visibility ToVisibility(this bool arg)
        {
            return arg ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// конвертація в bool
        /// </summary>
        /// <param name="arg">значення для конвертації</param>
        /// <returns></returns>
        public static bool ToBool(this Visibility arg)
        {
            return arg == Visibility.Visible;
        }

        /// <summary>
        /// Визначає чи число входить в діапазон.
        /// </summary>
        /// <param name="value">Значення.</param>
        /// <param name="min">Мінімальна границя.</param>
        /// <param name="max">Таксимальна границя.</param>
        /// <returns></returns>
        public static bool IsBeetwen(this decimal value, decimal min, decimal max)
        {
            return value >= min && value < max;
        }

        /// <summary>
        /// Визначає чи число входить в діапазон.
        /// </summary>
        /// <param name="value">Значення.</param>
        /// <param name="min">Мінімальна границя.</param>
        /// <param name="max">Таксимальна границя.</param>
        /// <returns></returns>
        public static bool IsBeetwen(this int value, int min, int max)
        {
            return value >= min && value < max;
        }
    }
}