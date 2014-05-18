using System.Windows;
using System.Windows.Controls;
using ARM.Module.Interfaces;

namespace ARM.Module.Helpers.Selectors
{
    public class ARMMainToolboxTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ButtonTemplate { get; set; }
        public DataTemplate SeparatorTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var data = item as IARMMainToolboxCommand;
            return data != null && data.IsSeparator ? SeparatorTemplate : ButtonTemplate;
        }
    }
}