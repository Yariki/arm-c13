using System;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using ARM.Infrastructure.Enums;
using TextBox = Microsoft.Office.Interop.Excel.TextBox;

namespace ARM.Infrastructure.Controls.ARMRequiredLabel
{
    public static class ARMRequiredLabel
    {
        private static char RequiredChar = '*';

        public static readonly DependencyProperty RequiredLabelProperty = DependencyProperty.RegisterAttached(
            "RequiredLabel", typeof(eARMRequiredLabel), typeof(ARMRequiredLabel), new PropertyMetadata(default(eARMRequiredLabel), RequiredChanged));

        private static void RequiredChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            TextBlock textBox = dependencyObject as TextBlock;
            if (textBox != null && !string.IsNullOrEmpty(textBox.Text))
            {
                eARMRequiredLabel req = (eARMRequiredLabel)dependencyPropertyChangedEventArgs.NewValue;
                switch (req)
                {
                    case eARMRequiredLabel.Required:
                        textBox.Text = string.Format("{0} *", textBox.Text);
                        break;
                    default:
                        if (textBox.Text.IndexOf(RequiredChar) > -1)
                        {
                            textBox.Text = textBox.Text.Replace(RequiredChar,' ');
                        }
                        break;
                }
                return;
            }
        }

        public static void SetRequiredLabel(DependencyObject element, eARMRequiredLabel value)
        {
            element.SetValue(RequiredLabelProperty, value);
        }

        public static eARMRequiredLabel GetRequiredLabel(DependencyObject element)
        {
            return (eARMRequiredLabel)element.GetValue(RequiredLabelProperty);
        }
    }
}