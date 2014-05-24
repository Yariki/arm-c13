using System;
using System.Collections.Generic;
using System.Windows.Input;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Core.MVVM;
using ARM.Core.Service;
using ARM.Data.Models;
using ARM.Data.Sevice.Resolver;
using ARM.Infrastructure.Controls.Interfaces;
using ARM.Infrastructure.Events;
using ARM.Infrastructure.Events.EventPayload;
using ARM.Infrastructure.MVVM;
using Microsoft.Practices.Prism.Events;
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
        private IEventAggregator _eventAggregator;

        /// <summary>
        /// Ініціалізує новий екземпляр класу <see cref="ARMLookupViewModel"/>.
        /// </summary>
        /// <param name="unityContainer">Контейнер IoC.</param>
        /// <param name="view">Користувацький інтерфейс.</param>
        public ARMLookupViewModel(IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMView view)
            : base(view)
        {
            _unityContainer = unityContainer;
            _eventAggregator = eventAggregator;
            AddEntityCommand = new ARMRelayCommand(AddEntityExecute);
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

        /// <summary>
        /// Команда для створення обєкту обраного типу.
        /// </summary>
        public ICommand AddEntityCommand { get; private set; }
        /// <summary>
        /// Викликається при відміні вводу.
        /// </summary>
        public event EventHandler Cancel;

        /// <summary>
        /// ОТримує шлях до зображення.
        /// </summary>
        public string ImagePath { get { return @"pack://application:,,,/ARM.Resource;component/Images/data-add-icon.png";  } }

        /// <summary>
        /// Викликається при відміні.
        /// </summary>
        protected virtual void OnCancel()
        {
            EventHandler handler = Cancel;
            if (handler != null) 
                handler(this, EventArgs.Empty);
        }

        /// <summary>
        /// Відображає форму для додавання нового обєкта та закриває вікно вибору.
        /// </summary>
        /// <param name="arg">The argument.</param>
        private void AddEntityExecute(object arg)
        {
            if(_eventAggregator == null)
                return;
            var eventProcess = _eventAggregator.GetEvent<ARMEntityProcessEvent>();
            if(eventProcess == null)
                return;
            eventProcess.Publish(new ARMProcessEntityEventPayload(Metadata,ViewMode.Add, Guid.Empty));
            OnCancel();
        }
    }
}