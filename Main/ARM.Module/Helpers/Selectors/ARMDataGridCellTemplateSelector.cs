using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ARM.Module.Helpers.AttachedProperty;

namespace ARM.Module.Helpers.Selectors
{
    /// <summary>
    /// Класс-селектор для шаблонів елемента DataGrid.
    /// Використовує звичайний строковий шаблон для всіх колонок, крім колонок типу DataGridTemplateColumn.
    /// Для такиїх колонок селектор повертає значення DetailsTemplate.
    /// </summary>
    public class ARMDataGridCellTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Отримує  або задає строковий шаблон.
        /// </summary>
        public DataTemplate StringTemplate { get; set; }
        /// <summary>
        /// Отримує або задає детальний шаблон.
        /// </summary>
        /// <value>
        /// The details template.
        /// </value>
        public DataTemplate DetailsTemplate { get; set; }

        /// <summary>
        /// ОТримує або задає шаблон для обєкта, який рівний null.
        /// </summary>
        public DataTemplate NullTemplate { get; set; }

        /// <summary>
        /// При перевизначенні в похідному класі повертає <see cref="T:System.Windows.DataTemplate" /> на основі власної логіки.
        /// </summary>
        /// <param name="item">Об'єкт даних, для якого обирається шаблон.</param>
        /// <param name="container">Контейнер.</param>
        /// <returns>
        /// Returns a <see cref="T:System.Windows.DataTemplate" /> or null. The default value is null.
        /// </returns>
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