using ARM.Core.Interfaces;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Infrastructure.MVVM
{
    /// <summary>
    /// Базовий класс для всіх класів сервісів.
    /// Дані класи призначені для дій над даними. Такі як, розрахунки і т.д.
    /// </summary>
    public abstract class ARMServiceViewModelBase : ARMWorkspaceViewModelBase
    {
        /// <summary>
        /// Ініціалізує новий екземпляр класу <see cref="ARMServiceViewModelBase"/>.
        /// </summary>
        /// <param name="regionManager">Менеджер регіонів.</param>
        /// <param name="unityContainer">Контейнер IoC.</param>
        /// <param name="eventAggregator">Агрегатор подій.</param>
        /// <param name="view">The view.</param>
        protected ARMServiceViewModelBase(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }
    }
}