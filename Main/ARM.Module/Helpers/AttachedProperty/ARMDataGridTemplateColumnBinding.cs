using System.Windows;
using System.Windows.Data;

namespace ARM.Module.Helpers.AttachedProperty
{
    /// <summary>
    /// Статичний клас, який прзначений для реалізації приєднаної властиваості.
    /// Дана властивість призначена для передачі ідентифікатора предмету в колонку. Тому колонка буде 
    /// відображати результати успішності певного предмету.
    /// </summary>
    public static class ARMDataGridTemplateColumnBinding
    {
        /// <summary>
        /// Приєднана властивість.
        /// </summary>
        public static readonly DependencyProperty ColumnBindingProperty = DependencyProperty.RegisterAttached(
            "ColumnBinding", typeof (string), typeof (ARMDataGridTemplateColumnBinding), new PropertyMetadata(default(string)));

        /// <summary>
        /// Задати значення властивості.
        /// </summary>
        /// <param name="element">Приєднаний елемент.</param>
        /// <param name="value">Значення.</param>
        public static void SetColumnBinding(DependencyObject element, string value)
        {
            element.SetValue(ColumnBindingProperty, value);
        }

        /// <summary>
        /// Отримати значення властивості.
        /// </summary>
        /// <param name="element">Елемент.</param>
        /// <returns></returns>
        public static string GetColumnBinding(DependencyObject element)
        {
            return (string) element.GetValue(ColumnBindingProperty);
        }
    }
}