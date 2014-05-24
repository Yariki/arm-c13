using System.Windows;
using System.Windows.Controls;
using ARM.Module.Interfaces;

namespace ARM.Module.Helpers.Selectors
{
    /// <summary>
    /// Клас, що відповідає за вибір шаблону відображення для головного меню.
    /// </summary>
    public class ARMMainMenuTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Отримує або задає шаблон з іконкою.
        /// </summary>
        public DataTemplate IconTemplate { get; set; }
        /// <summary>
        /// Отримує або задає звичайний шаблон.
        /// </summary>
        public DataTemplate CommonTemplate { get; set; }

        /// <summary>
        /// Повертає шаблон відповідно до внутрішньої логіки.
        /// </summary>
        /// <param name="item">Обєrт контексту елемента, зазвичай це є модель представлення, команда тощо.</param>
        /// <param name="container">Елемент контейнер.</param>
        /// <returns>
        /// Повертає шаблон.
        /// </returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var cmd = item as IARMMenuCommand;
            return cmd != null && cmd.HasIcon ? IconTemplate : CommonTemplate;
        }
    }
}