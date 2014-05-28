using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using ARM.Core.Interfaces;

namespace ARM.Core.Reflection
{
    /// <summary>
    /// Простір імен, який містить класи кешування метолів та властивостей типів даних.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    internal class NamespaceDoc
    {
    }

    /// <summary>
    /// класс-контейнер для зберігання інформації по властивостям певного типу
    /// </summary>
    public class ARMModelPropertyInfo : IARMModelPropertyInfo
    {
        /// <summary>
        /// Ініціалізує новий екземпляр класу <see cref="ARMModelPropertyInfo"/>.
        /// </summary>
        /// <param name="pi">Екземпляр PropertyInfo.</param>
        /// <param name="isRequired">Обовязкове до заповнення.</param>
        /// <param name="validationAttribute">Атрибут валідації.</param>
        /// <param name="visibleInGrid">Присутнє в сітці.</param>
        /// <param name="orderInGrid">Порядок в сітці.</param>
        /// <param name="displayAttribute">Атрибут для знаходження локалізованих даних.</param>
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

        /// <summary>
        /// Повертає властивість
        /// </summary>
        public PropertyInfo Property { get; private set; }

        /// <summary>
        /// Повертає знаячення, що показує, ща властивість є обовязковоє до заповнення.
        /// </summary>
        /// <value>
        ///   <c>true</c> якщо обовязкова; інакше, <c>false</c>.
        /// </value>
        public bool IsRequired { get; private set; }

        /// <summary>
        /// Повертає тип результату
        /// </summary>
        public Type ReturnType { get; private set; }

        /// <summary>
        /// Повертає атрибут валідації
        /// </summary>
        public IARMValidationAttribute ValidationAttribute { get; private set; }

        /// <summary>
        /// Чи властивість повинна відображатись у сітці
        /// </summary>
        /// <value>
        ///   <c>true</c> якшо повинна відображатись; інакше, <c>false</c>.
        /// </value>
        public bool VisibleInGrid { get; private set; }

        /// <summary>
        /// Повертає індекс відображення в сітці
        /// </summary>
        /// <value>
        /// The order in grid.
        /// </value>
        public int OrderInGrid { get; private set; }

        /// <summary>
        /// Атрибут для локалізації. За допомогою цього атрибуту можна вибрати локалізовані дані
        /// </summary>
        public DisplayAttribute Display { get; private set; }
    }
}