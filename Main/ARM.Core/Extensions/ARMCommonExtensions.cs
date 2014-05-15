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

    }
}