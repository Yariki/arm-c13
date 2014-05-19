using System;
using ARM.Core.Enums;
using ARM.Module.Enums;
using ARM.Module.Interfaces;

namespace ARM.Module.Commands.Toolbar
{
    /// <summary>
    /// Базова команда для головної панелі управління.
    /// </summary>
    public abstract class ARMBaseMainToolboxCommand : IARMMainToolboxCommand
    {
        private Action<eARMMainMenuCommand> _action;
        private Func<eARMMainMenuCommand, bool> _predicate;


        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="predicate">Предикат.</param>
        protected ARMBaseMainToolboxCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand,bool> predicate )
        {
            _action = action;
            _predicate = predicate;
        }

        /// <summary>
        /// Виконує певну дію при натисканні на кнопку користувачем.
        /// </summary>
        /// <param name="parameter">Даня для методу.</param>
        public void Execute(object parameter)
        {
            if (_action != null)
            {
                _action(ToolbarCommand);
            }
        }

        /// <summary>
        /// Визначає, яи може виконатисб команда в даному режимі.
        /// </summary>
        /// <param name="parameter">Дані для команди.</param>
        /// <returns>
        /// true якщо може виконатись, інакше, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return _predicate != null && _predicate(ToolbarCommand);
        }

        /// <summary>
        /// Виконується при зміі стану елемента.
        /// </summary>
        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// Заголовок команди
        /// </summary>
        public string Title { get; protected set; }
        /// <summary>
        /// Картинка команди
        /// </summary>
        public string Image 
        {
            get { return GetImagePath(); }
        }
        /// <summary>
        /// Імя ресурсу
        /// </summary>
        public string ResourceName { get; protected set; }
        /// <summary>
        /// Підказка команди
        /// </summary>
        public string Tooltip { get; protected set; }
        /// <summary>
        /// Додатковий аргумент.
        /// </summary>
        public object Tag { get; protected set; }
        /// <summary>
        /// Тип команди.
        /// </summary>
        public ToolbarCommand Type { get; private set; }
        /// <summary>
        /// Порядок відображення.
        /// </summary>
        public int Order { get; protected set; }
        /// <summary>
        /// Отримує тип команди панелі управління.
        /// </summary>
        public eARMMainMenuCommand ToolbarCommand { get; protected set; }
        /// <summary>
        /// Отримує значення, чи являється команда роздільником.
        /// </summary>
        public bool IsSeparator { get; protected set; }

        /// <summary>
        /// Отримує шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected virtual string GetImagePath()
        {
            return string.Empty;
        }
    }
}