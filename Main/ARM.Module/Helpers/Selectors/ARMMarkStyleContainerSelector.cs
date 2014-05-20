using System.Windows;
using System.Windows.Controls;
using ARM.Data.Models;

namespace ARM.Module.Helpers.Selectors
{
    /// <summary>
    /// Класс-селектор, котрий повертає шаблон для звичаних оцінок та атестацій.
    /// </summary>
    public class ARMMarkStyleContainerSelector :  StyleSelector
    {

        /// <summary>
        /// Отримує або зада загальний шаблон.
        /// </summary>
        /// <value>
        /// The normal.
        /// </value>
        public Style Normal { get; set; }

        /// <summary>
        /// Отримує або задає шаблон для атестацій.
        /// </summary>
        /// <value>
        /// The certification.
        /// </value>
        public Style Certification { get; set; }

        /// <summary>
        /// Повертає шаблон відповідно до внутрішньої логіки.
        /// </summary>
        /// <param name="item">Обєекет контексту елемента, зазвичай це є модель представлення, команда тощо.</param>
        /// <param name="container">Елемент контейнер.</param>
        /// <returns>
        /// Повертає шаблон.
        /// </returns>
        public override Style SelectStyle(object item, DependencyObject container)
        {
            var mark = item as Mark;
            if (mark == null)
                return Normal;
            return mark.Type != MarkType.Certification ? Normal : Certification;
        }
    }
}