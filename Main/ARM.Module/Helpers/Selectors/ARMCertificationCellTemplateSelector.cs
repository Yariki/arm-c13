using System.Windows;
using System.Windows.Controls;

namespace ARM.Module.Helpers.Selectors
{
    public class ARMCertificationCellTemplateSelector : DataTemplateSelector
    {
        public DataTemplate StringTemplate { get; set; }
        public DataTemplate DetailsTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //if (item is string)
            {
                return StringTemplate;
            }
            //return DetailsTemplate;
        }
    }
}