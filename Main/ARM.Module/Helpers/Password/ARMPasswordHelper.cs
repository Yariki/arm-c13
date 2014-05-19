using System.Windows;
using System.Windows.Controls;

namespace ARM.Module.Helpers.Password
{
    /// <summary>
    /// Статичний клас, який забеспечує допоміжну функціональність для елемента PasswordBox.
    /// Забеспечує привязку значення до властивості моделі представлення. Також його оновлення.
    /// </summary>
    public static class ARMPasswordHelper
    {
        /// <summary>
        /// Властивіть дял пароля.
        /// </summary>
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password",
            typeof(string), typeof(ARMPasswordHelper),
            new FrameworkPropertyMetadata(string.Empty, OnPasswordPropertyChanged));

        /// <summary>
        /// Властивість привязки.
        /// </summary>
        public static readonly DependencyProperty AttachProperty =
            DependencyProperty.RegisterAttached("Attach",
            typeof(bool), typeof(ARMPasswordHelper), new PropertyMetadata(false, Attach));

        /// <summary>
        /// Властивість оновлення.
        /// </summary>
        private static readonly DependencyProperty IsUpdatingProperty =
           DependencyProperty.RegisterAttached("IsUpdating", typeof(bool),
           typeof(ARMPasswordHelper));


        /// <summary>
        /// Задати властивість.
        /// </summary>
        /// <param name="dp">Елемент.</param>
        /// <param name="value">Значення.</param>
        public static void SetAttach(DependencyObject dp, bool value)
        {
            dp.SetValue(AttachProperty, value);
        }

        /// <summary>
        /// Отримати значення властивості.
        /// </summary>
        /// <param name="dp">Елемент.</param>
        /// <returns></returns>
        public static bool GetAttach(DependencyObject dp)
        {
            return (bool)dp.GetValue(AttachProperty);
        }
        /// <summary>
        /// Отримати значення властивості.
        /// </summary>
        /// <param name="dp">Елемент.</param>
        /// <returns></returns>
        public static string GetPassword(DependencyObject dp)
        {
            return (string)dp.GetValue(PasswordProperty);
        }
        /// <summary>
        /// Задати властивість.
        /// </summary>
        /// <param name="dp">Елемент.</param>
        /// <param name="value">Значення.</param>
        public static void SetPassword(DependencyObject dp, string value)
        {
            dp.SetValue(PasswordProperty, value);
        }
        /// <summary>
        /// Отримати значення властивості.
        /// </summary>
        /// <param name="dp">Елемент.</param>
        /// <returns></returns>
        private static bool GetIsUpdating(DependencyObject dp)
        {
            return (bool)dp.GetValue(IsUpdatingProperty);
        }
        /// <summary>
        /// Задати властивість.
        /// </summary>
        /// <param name="dp">Елемент.</param>
        /// <param name="value">Значення.</param>
        private static void SetIsUpdating(DependencyObject dp, bool value)
        {
            dp.SetValue(IsUpdatingProperty, value);
        }

        /// <summary>
        /// Визивається при зміні властивості паролю.
        /// </summary>
        /// <param name="sender">Елемент, що килкикає.</param>
        /// <param name="e">Аргументи події.</param>
        private static void OnPasswordPropertyChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            passwordBox.PasswordChanged -= PasswordChanged;

            if (!(bool)GetIsUpdating(passwordBox))
            {
                passwordBox.Password = (string)e.NewValue;
            }
            passwordBox.PasswordChanged += PasswordChanged;
        }
        /// <summary>
        /// Визивається при зміні привязки.
        /// </summary>
        /// <param name="sender">Елемент, що килкикає.</param>
        /// <param name="e">Аргументи події.</param>
        private static void Attach(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;

            if (passwordBox == null)
                return;

            if ((bool)e.OldValue)
            {
                passwordBox.PasswordChanged -= PasswordChanged;
            }

            if ((bool)e.NewValue)
            {
                passwordBox.PasswordChanged += PasswordChanged;
            }
        }
        /// <summary>
        /// Визивається при зміні паролю.
        /// </summary>
        /// <param name="sender">Елемент, що килкикає.</param>
        /// <param name="e">Аргументи події.</param>
        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            SetIsUpdating(passwordBox, true);
            SetPassword(passwordBox, passwordBox.Password);
            SetIsUpdating(passwordBox, false);
        }
    }
}