///////////////////////////////////////////////////////////
//  ARMStringAttribute.cs
//  Implementation of the Class ARMStringAttribute
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 4:59:43 PM
///////////////////////////////////////////////////////////

namespace ARM.Core.Attributes
{
    /// <summary>
    ///     базовий класс для артибутів по валідації строковиї властивостей
    /// </summary>
    public abstract class ARMStringAttribute : ARMValidationAttribute
    {
        /// <summary>
        ///     Шаблон, у відповідності до якого проводиться валідація
        /// </summary>
        public string Pattern { get; set; }

        ~ARMStringAttribute()
        {
        }
    } //end ARMStringAttribute
} //end namespace Attributes