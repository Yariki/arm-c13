using System;
using System.Collections.Generic;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Core.MVVM;
using ARM.Core.Service;
using ARM.Data.Models;
using ARM.Data.Sevice.Resolver;
using ARM.Infrastructure.Controls.Interfaces;
using Microsoft.Practices.Unity;

namespace ARM.Infrastructure.Controls.ARMLookupWindow
{
    /// <summary>
    /// Модель представлення яка прює разом з ARMLookupControl.
    /// Дана модель призначена для відображення сітки з даними та вибору елемента.
    /// </summary>
    public class ARMLookupViewModel : ARMViewModelBase, IARMLookupViewModel
    {
        private IUnityContainer _unityContainer;

        /// <summary>
        /// Ініціалізує новий екземпляр класу <see cref="ARMLookupViewModel"/>.
        /// </summary>
        /// <param name="unityContainer">Контейнер IoC.</param>
        /// <param name="view">Користувацький інтерфейс.</param>
        public ARMLookupViewModel(IUnityContainer unityContainer, IARMView view)
            : base(view)
        {
            _unityContainer = unityContainer;
        }

        /// <summary>
        /// Дані для сітки
        /// </summary>
        public IEnumerable<object> Source { get; private set; }

        /// <summary>
        /// Метадата
        /// </summary>
        public eARMMetadata Metadata { get; private set; }

        /// <summary>
        /// Повертає тип моделі даних
        /// </summary>
        public Type EntityType { get; private set; }

        /// <summary>
        /// Отримує  або задає вибраний елемент.
        /// </summary>
        public BaseModel SelectedItem { get; set; }

        /// <summary>
        /// Ініціалізує вказаними метаданими.
        /// </summary>
        /// <param name="metadata">Метадата.</param>
        public void Initialize(eARMMetadata metadata)
        {
            var resolver = _unityContainer.Resolve<IARMDataModelResolver>();
            if (resolver == null)
                return;
            Metadata = metadata;
            EntityType = ARMModelsPropertyCache.Instance.GetTypeByMetadata(Metadata);
            Source = resolver.GetAllByMetadata(Metadata);

            OnPropertyChanged(() => Source);
            OnPropertyChanged(() => EntityType);
        }
    }
}