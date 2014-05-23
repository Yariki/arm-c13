using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using ARM.Core.Interfaces;
using ARM.Core.Service;
using Xceed.Wpf.DataGrid;

namespace ARM.Infrastructure.Controls
{
    /// <summary>
    /// Елемент управління для відображення певної моделі даних в сітці.
    /// </summary>
    public class ARMDataGridControl : DataGridControl
    {
        #region [ctor]

        public ARMDataGridControl()
            : base()
        {
            AutoCreateColumns = false;
            ReadOnly = true;
        }

        #endregion [ctor]

        #region [depedency property]

        #region [type of entity]

        public static readonly DependencyProperty TypeOfEntityProperty = DependencyProperty.Register(
            "TypeOfEntity", typeof(Type), typeof(ARMDataGridControl), new PropertyMetadata(default(Type), TypeOfEntityChanged));

        private static void TypeOfEntityChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            if (dependencyPropertyChangedEventArgs.NewValue != null)
            {
                ((ARMDataGridControl)dependencyObject).TypeOfEntityChanged((Type)dependencyPropertyChangedEventArgs.NewValue);
            }
        }

        public Type TypeOfEntity
        {
            get { return (Type)GetValue(TypeOfEntityProperty); }
            set { SetValue(TypeOfEntityProperty, value); }
        }

        public void TypeOfEntityChanged(Type newType)
        {
            List<IARMModelPropertyInfo> propertyInfos = ARMModelsPropertyCache.Instance.GetPropertyInfos(newType);
            if (propertyInfos == null || !propertyInfos.Any())
                return;
            foreach (var armModelPropertyInfo in propertyInfos.Where(p => p.VisibleInGrid).OrderBy(p => p.OrderInGrid))
            {
                var column = new Column();
                column.FieldName = armModelPropertyInfo.Property.Name;
                column.Title = armModelPropertyInfo.Display != null ? armModelPropertyInfo.Display.GetName() : armModelPropertyInfo.Property.Name;
                column.Width = 150;
                this.Columns.Add(column);
            }

        }

        #endregion [type of entity]

        #endregion [depedency property]
    }
}