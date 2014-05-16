using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using ARM.Core.Interfaces;

namespace ARM.Core.Reflection
{
    public class ARMModelPropertyInfo : IARMModelPropertyInfo
    {
        public ARMModelPropertyInfo(PropertyInfo pi, bool isRequired, IARMValidationAttribute validationAttribute, bool visibleInGrid, int orderInGrid, DisplayAttribute displayAttribute)
        {
            Property = pi;
            IsRequired = isRequired;
            ReturnType = Property != null ? Property.PropertyType : null;
            ValidationAttribute = validationAttribute;
            VisibleInGrid = visibleInGrid;
            Display = displayAttribute;
            OrderInGrid = orderInGrid;
        }

        public PropertyInfo Property { get; private set; }

        public bool IsRequired { get; private set; }

        public Type ReturnType { get; private set; }

        public IARMValidationAttribute ValidationAttribute { get; private set; }

        public bool VisibleInGrid { get; private set; }

        public int OrderInGrid { get; private set; }

        public DisplayAttribute Display { get; private set; }
    }
}