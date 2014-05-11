using System.Windows;
using System.Windows.Data;

namespace ARM.Module.Helpers.AttachedProperty
{
    public static class ARMDataGridTemplateColumnBinding
    {
        public static readonly DependencyProperty ColumnBindingProperty = DependencyProperty.RegisterAttached(
            "ColumnBinding", typeof (string), typeof (ARMDataGridTemplateColumnBinding), new PropertyMetadata(default(string)));

        public static void SetColumnBinding(DependencyObject element, string value)
        {
            element.SetValue(ColumnBindingProperty, value);
        }

        public static string GetColumnBinding(DependencyObject element)
        {
            return (string) element.GetValue(ColumnBindingProperty);
        }
    }
}