using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using Xceed.Wpf.DataGrid;
using Xceed.Wpf.DataGrid.FilterCriteria;

namespace ARM.Infrastructure.Controls.Filter
{
    /// <summary>
    /// Класс призначений для фильтрації даних в сітці.
    /// </summary>
    public class ARMFilterRow : Row, IDisposable
    {

        #region [needs]

        private readonly Dictionary<ColumnBase, ARMFilterCell> _filtersCells = new Dictionary<ColumnBase, ARMFilterCell>(); 

        #endregion
        
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
            "Source", typeof (DataGridCollectionViewSource), typeof (ARMFilterRow), new PropertyMetadata(default(DataGridCollectionViewSource)));

        /// <summary>
        /// Отримує або задає колекцію даних, яку потрібно фільтрувати.
        /// </summary>
        public DataGridCollectionViewSource Source
        {
            get { return (DataGridCollectionViewSource) GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
     
        /// <summary>
        /// Створює ячейку.
        /// </summary>
        /// <param name="column">Колонка.</param>
        /// <returns></returns>
        protected override Cell CreateCell(ColumnBase column)
        {
            _filtersCells[column] = new ARMFilterCell(column);
            _filtersCells[column].ApplyCriteria += OnApplyCriteria;
            return _filtersCells[column];
        }

        /// <summary>
        /// Викликається при зміні певного критерію.
        /// Якщо значення критерію наявне, то додається або обновлюється критерія.
        /// Якщо значення критерія пусте, то воно видаляється.
        /// </summary>
        /// <param name="sender">Відправник.</param>
        /// <param name="armApplyCritetiaEventArgs">Аргументи з даними.</param>
        private void OnApplyCriteria(object sender, ARMApplyCritetiaEventArgs armApplyCritetiaEventArgs)
        {
            if (Source == null || armApplyCritetiaEventArgs == null)
                return;

            if (Source.ItemProperties.Any(i => i.Name == armApplyCritetiaEventArgs.PropertyName))
            {
                var itemProperty = Source.ItemProperties.First(i => i.Name == armApplyCritetiaEventArgs.PropertyName);
                itemProperty.FilterCriterion = !string.IsNullOrEmpty(armApplyCritetiaEventArgs.Value) ? new ContainsFilterCriterion(armApplyCritetiaEventArgs.Value) : null;
            }
            else if(!string.IsNullOrEmpty(armApplyCritetiaEventArgs.Value))
            {
                var itemProperty = new DataGridItemProperty() {Name = armApplyCritetiaEventArgs.PropertyName,DataType = typeof(string)};
                itemProperty.FilterCriterion = new ContainsFilterCriterion(armApplyCritetiaEventArgs.Value);
                Source.ItemProperties.Add(itemProperty);    
            }
        }

        /// <summary>
        /// Перевірка на правильність типу ячейки.
        /// </summary>
        /// <param name="cell">Ячейка.</param>
        /// <returns></returns>
        protected override bool IsValidCellType(Cell cell)
        {
            return cell is ARMFilterCell;
        }


        /// <summary>
        /// Визначаються додатком завдання, пов'язані з вивільненням або скиданням некерованих ресурсів.
        /// </summary>
        public void Dispose()
        {
            if (_filtersCells != null && _filtersCells.Count > 0)
            {
                foreach (var armFilterCell in _filtersCells)
                {
                    armFilterCell.Value.ApplyCriteria -= OnApplyCriteria;
                }
            }
            GC.SuppressFinalize(this);
        }
    }
}