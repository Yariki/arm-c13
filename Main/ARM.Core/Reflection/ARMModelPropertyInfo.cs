using System;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using ARM.Core.Interfaces;

namespace ARM.Core.Reflection
{
    public class ARMModelPropertyInfo : IARMModelPropertyInfo
    {
        public ARMModelPropertyInfo(PropertyInfo pi, bool isRequired,IARMValidationAttribute validationAttribute)
        {
            Property = pi;
            IsRequired = isRequired;
            ReturnType = Property != null ? Property.PropertyType : null;
            ValidationAttribute = validationAttribute;
        }
    
        public PropertyInfo Property { get; private set; }
        public bool IsRequired { get; private set; }
        public Type ReturnType { get; private set; }
        public IARMValidationAttribute ValidationAttribute { get; private set; }
    }
}