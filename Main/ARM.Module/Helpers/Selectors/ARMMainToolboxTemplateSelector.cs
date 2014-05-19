using System.Windows;
using System.Windows.Controls;
using ARM.Module.Interfaces;

namespace ARM.Module.Helpers.Selectors
{
    /// <summary>
    /// Клас, що відповідає за вибір шаблону відображення для панелі упрпавління.
    /// </summary>
    public class ARMMainToolboxTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Отримує або задає шаблон кнопки.
        /// </summary>
        public DataTemplate ButtonTemplate { get; set; }
        /// <summary>
        /// Отримує  або задає шаблон роздільника.
        /// </summary>
        public DataTemplate SeparatorTemplate { get; set; }
        /// <summary>
        /// Повертає шаблон відповідно до внутрішньої логіки.
        /// </summary>
        /// <param name="item">Обєекет контексту елемента, зазвичай це є модель представлення, команда тощо.</param>
        /// <param name="container">Елемент контейнер.</param>
        /// <returns>
        /// Повертає шаблон.
        /// </returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var data = item as IARMMainToolboxCommand;
            return data != null && data.IsSeparator ? SeparatorTemplate : ButtonTemplate;
        }
    }
}