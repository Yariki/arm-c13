using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

/// <summary>
/// Простір імен що містить клас, який відповідає за базову логіку  для ініціалізації всіх модулів програми.
/// </summary>
namespace ARM.Core.Module
{
  /// <summary>
  /// Базовий класс для всіх модулів.
  /// </summary>
    public abstract class ARMBaseModule : IModule
    {
        #region [needs]

      /// <summary>
      /// Менеджер областей.
      /// </summary>
        protected readonly IRegionManager RegionManager;
        /// <summary>
        /// Контейнер IoC.
        /// </summary>
        protected readonly IUnityContainer UnityContainer;
        /// <summary>
        /// Агрегатор подій.
        /// </summary>
        protected readonly IEventAggregator EventAggregator;

        #endregion [needs]

        /// <summary>
        /// Ініціалізує новий екземпляр класу.
        /// </summary>
        /// <param name="regionManager">Менеджер областей.</param>
        /// <param name="unityContainer">Контейнер IoC.</param>
        /// <param name="eventAggregator">Агрегатор подій.</param>
        protected ARMBaseModule(IRegionManager regionManager, IUnityContainer unityContainer,
            IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            RegionManager = regionManager;
            UnityContainer = unityContainer;
        }

        /// <summary>
        /// Повідомляє модуль, що вона буде инициализирована.
        /// </summary>
        public void Initialize()
        {
            RegistreInterfaces();
            InjectViews();
            InternalInitialize();
        }

        /// <summary>
        /// Реєстрація інтерфейсів.
        /// </summary>
        protected virtual void RegistreInterfaces()
        {
        }

        /// <summary>
        /// Підготовка користувацьокого інтерфейсу
        /// </summary>
        protected virtual void InjectViews()
        {
        }

        /// <summary>
        /// Внутрішня ініціалізація.
        /// </summary>
        protected virtual void InternalInitialize()
        {
        }
    }
}