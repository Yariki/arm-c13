using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ARM.Module.Helpers.Selectors;
using Microsoft.Practices.ObjectBuilder2;

namespace ARM.Module.Helpers.AttachedProperty
{
    public static class ARMGridViewColumnSource
    {
        public static readonly DependencyProperty ColumnsSourceProperty = DependencyProperty.RegisterAttached(
            "ColumnsSource", typeof(ObservableCollection<DataGridColumn>), typeof(ARMGridViewColumnSource), new PropertyMetadata(default(ObservableCollection<DataGridColumn>), ColumnsSourceChanged));

        private static void ColumnsSourceChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var gridView = dependencyObject as DataGrid;
            if(gridView == null)
                return;
            gridView.Columns.Clear();
            var columns = args.NewValue as ObservableCollection<DataGridColumn>;
            if (columns != null)
            {
                var selector = (DataTemplateSelector)gridView.GetValue(ARMGridViewColumnSource.CertificationCellTemplateSelectorProperty);
                columns.ForEach(col =>
                {
                    var templateCol = col as DataGridTemplateColumn;
                    if (templateCol != null)
                    {
                        templateCol.CellTemplateSelector = selector;
                    }
                    gridView.Columns.Add(col);
                });
            }
        }

        public static void SetColumnsSource(DependencyObject element, ObservableCollection<DataGridColumn> value)
        {
            element.SetValue(ColumnsSourceProperty, value);
        }

        public static ObservableCollection<DataGridColumn> GetColumnsSource(DependencyObject element)
        {
            return (ObservableCollection<DataGridColumn>)element.GetValue(ColumnsSourceProperty);
        }

        public static readonly DependencyProperty CertificationCellTemplateSelectorProperty = DependencyProperty.RegisterAttached(
            "CertificationCellTemplateSelector", typeof (DataTemplateSelector), typeof (ARMGridViewColumnSource), new PropertyMetadata(default(DataTemplateSelector)));

        public static void SetCertificationCellTemplateSelector(DependencyObject element, DataTemplateSelector value)
        {
            element.SetValue(CertificationCellTemplateSelectorProperty, value);
        }

        public static DataTemplateSelector GetCertificationCellTemplateSelector(DependencyObject element)
        {
            return (DataTemplateSelector) element.GetValue(CertificationCellTemplateSelectorProperty);
        }

    }
}