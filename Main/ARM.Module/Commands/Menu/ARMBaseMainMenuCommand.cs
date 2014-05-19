using System;
using ARM.Module.Enums;
using ARM.Module.Interfaces;

namespace ARM.Module.Commands.Menu
{
    /// <summary>
    /// Базовий клас для команд головного меню.
    /// </summary>
    public abstract class ARMBaseMainMenuCommand : IARMMenuCommand
    {
        private readonly Action<eARMMainMenuCommand> _action;
        private readonly Func<eARMMainMenuCommand, bool> _canExecute;

        /// <summary>
        /// Створення нового екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="canPredicate">Предикат.</param>
        protected ARMBaseMainMenuCommand(Action<eARMMainMenuCommand> action,
            Func<eARMMainMenuCommand, bool> canPredicate)
        {
            _action = action;
            _canExecute = canPredicate;
        }

        #region IARMMenuCommand Members

        /// <summary>
        /// Викликається при натисканні на пунктменю.
        /// </summary>
        /// <param name="parameter">Дані для команди.</param>
        public void Execute(object parameter)
        {
            if (_action != null)
            {
                _action(MenuCommand);
            }
        }

        /// <summary>
        /// Визначає чи може команда бути виконана.
        /// </summary>
        /// <param name="parameter">Дані команди.</param>
        /// <returns>
        /// Повертає true якщо може бути виконана, інакше false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute(MenuCommand);
        }

        /// <summary>
        /// Відбувається, коли зміни відбуваються, які впливають, чи повинен команда виконати.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Отримує або задає заголовок команди.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Отримує або задає підказку.
        /// </summary>
        public string Tooltip { get; set; }

        /// <summary>
        /// Отримує тип команди меню.
        /// </summary>
        public eARMMainMenuCommand MenuCommand { get; protected set; }
        /// <summary>
        /// Отримує шлях до іконки.
        /// </summary>
        public string Icon 
        {
            get { return GetIconPath(); }
        }

        /// <summary>
        /// Отримує значення, чи команда має іконку.
        /// </summary>
        public bool HasIcon
        {
            get { return !string.IsNullOrEmpty(Icon); }
        }

        #endregion IARMMenuCommand Members

        /// <summary>
        /// Повертає шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected virtual string GetIconPath()
        {
            return string.Empty;
        }
    }
}