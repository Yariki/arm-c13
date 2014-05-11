using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ARM.Module.Helpers.AttachedProperty;

namespace ARM.Module.Helpers.Selectors
{
    public class ARMCertificationCellTemplateSelector : DataTemplateSelector
    {
        public DataTemplate StringTemplate { get; set; }
        public DataTemplate DetailsTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            ContentPresenter presenter = container as ContentPresenter;
            DataGridCell cell = presenter.Parent as DataGridCell;
            var col = cell.Column;
            if (col is DataGridTemplateColumn)
            {
                var bindProperty =
                    (col as DataGridTemplateColumn).GetValue(ARMDataGridTemplateColumnBinding.ColumnBindingProperty) as
                        string;
                var binding = new Binding(bindProperty);
                binding.Source = cell.DataContext;
                BindingOperations.SetBinding(container, ContentPresenter.ContentProperty, binding);
                return DetailsTemplate;
            }
            return StringTemplate;
        }
    }
}