using System.Windows;
using System.Windows.Controls;
using ARM.Infrastructure.MVVM;

namespace ARM.Module.Helpers.WorkspaceSelector
{
    /// <summary>
    /// Клас-селектор для шаблонів головного інтерфейсу.
    /// </summary>
    public class ARMWorkspaceSelector : DataTemplateSelector
    {
        private const string GridSuffix = "Grid";

        /// <summary>
        /// Отримує або задає шаблон сітки.
        /// </summary>
        public DataTemplate GridViewModel { get; set; }

        /// <summary>
        /// Отримує або задає шаблон для робота з моделями даних.
        /// </summary>
        public DataTemplate DataViewModel { get; set; }

        /// <summary>
        /// Отримує або задає шаблон для звітів.
        /// </summary>
        public DataTemplate ReportViewModel { get; set; }

        /// <summary>
        /// Задає або отримує шаблон для сервісів.
        /// </summary>
        public DataTemplate ServiceViewModel { get; set; }
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
            if (item.GetType().Name.Contains(GridSuffix))
            {
                return GridViewModel;
            }
            if (item is ARMDataViewModelBase)
            {
                return DataViewModel;
            }
            if (item is ARMReportViewModelBase)
            {
                return ReportViewModel;
            }
            if (item is ARMServiceViewModelBase)
            {
                return ServiceViewModel;
            }
            return null;
        }
    }
}