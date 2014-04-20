using System.Windows;
using System.Windows.Controls;
using ARM.Infrastructure.MVVM;

namespace ARM.Module.Helpers.WorkspaceSelector
{
    public class ARMWorkspaceSelector : DataTemplateSelector
    {
        private const string GridSuffix = "Grid";

        public DataTemplate GridViewModel { get; set; }

        public DataTemplate DataViewModel { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item.GetType().Name.Contains(GridSuffix))
            {
                return GridViewModel;
            }
            if (item is ARMDataViewModelBase)
            {
                return DataViewModel;
            }
            return null;
        }
    }
}