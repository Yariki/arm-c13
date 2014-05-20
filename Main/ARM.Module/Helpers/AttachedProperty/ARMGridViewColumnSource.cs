using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ARM.Module.Helpers.Selectors;
using Microsoft.Practices.ObjectBuilder2;

namespace ARM.Module.Helpers.AttachedProperty
{
    /// <summary>
    /// Статичний класс який містить в соіб реалізіацію двох повязаних властивостей. 
    /// 1. ColumnsSource - відповідає за привязку колекцій колонок до сітки. Для динамічного формування набору колонок, в залежності від обраних, наприклад, предметів.
    /// 2. CertificationCellTemplateSelector - привязка до селектора шаблонів. В залежності як дані повинні відображатись, буде використовуватиьс той чи інший шаблон.
    /// </summary>
    public static class ARMGridViewColumnSource
    {
        /// <summary>
        /// Властивість привязки колонок.
        /// </summary>
        public static readonly DependencyProperty ColumnsSourceProperty = DependencyProperty.RegisterAttached(
            "ColumnsSource", typeof(ObservableCollection<DataGridColumn>), typeof(ARMGridViewColumnSource), new PropertyMetadata(default(ObservableCollection<DataGridColumn>), ColumnsSourceChanged));

        /// <summary>
        /// Занчення властивості підлягло зміні.
        /// </summary>
        /// <param name="dependencyObject">Елемент, до якого привязана властивість.</param>
        /// <param name="args">Аргументи містять як старе так і нове значення.</param>
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

        /// <summary>
        /// Задає значення властивості.
        /// </summary>
        /// <param name="element">Елемент.</param>
        /// <param name="value">Значення.</param>
        public static void SetColumnsSource(DependencyObject element, ObservableCollection<DataGridColumn> value)
        {
            element.SetValue(ColumnsSourceProperty, value);
        }

        /// <summary>
        /// Отримує значення властивості.
        /// </summary>
        /// <param name="element">Елемент.</param>
        /// <returns></returns>
        public static ObservableCollection<DataGridColumn> GetColumnsSource(DependencyObject element)
        {
            return (ObservableCollection<DataGridColumn>)element.GetValue(ColumnsSourceProperty);
        }

        /// <summary>
        /// Властивість для селектору шаблонів.
        /// </summary>
        public static readonly DependencyProperty CertificationCellTemplateSelectorProperty = DependencyProperty.RegisterAttached(
            "CertificationCellTemplateSelector", typeof (DataTemplateSelector), typeof (ARMGridViewColumnSource), new PropertyMetadata(default(DataTemplateSelector)));

        /// <summary>
        /// Задає значення властивості.
        /// </summary>
        /// <param name="element">Елемент.</param>
        /// <param name="value">The value.</param>
        public static void SetCertificationCellTemplateSelector(DependencyObject element, DataTemplateSelector value)
        {
            element.SetValue(CertificationCellTemplateSelectorProperty, value);
        }

        /// <summary>
        /// Отримати значення властивості.
        /// </summary>
        /// <param name="element">Елемент.</param>
        /// <returns></returns>
        public static DataTemplateSelector GetCertificationCellTemplateSelector(DependencyObject element)
        {
            return (DataTemplateSelector) element.GetValue(CertificationCellTemplateSelectorProperty);
        }

    }
}