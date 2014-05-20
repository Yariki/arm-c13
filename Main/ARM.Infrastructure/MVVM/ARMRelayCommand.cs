using System;
using System.Diagnostics;
using System.Windows.Input;

namespace ARM.Infrastructure.MVVM
{
    /// <summary>
    ///  Класс команди, яка відповідає за реалізацію інтерфейсу ICommand.
    /// </summary>
    public class ARMRelayCommand : ICommand
    {
        #region Fields

        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        #endregion Fields

        #region Constructors

        /// <summary>
        ///     Створює нову команду, яка завжди може виконувати.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public ARMRelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        ///     Створює нову команду.
        /// </summary>
        /// <param name="execute">Логіка виконання.</param>
        /// <param name="canExecute">Логіка статус виконання.</param>
        public ARMRelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion Constructors

        #region ICommand Members

        /// <summary>
        /// Визначає метод, який визначає, чи може команда виконуватися в її поточному стані.
        /// </summary>
        /// <param name="parameter">Дані, що використовуються командою. Якщо команда не вимагає дані повинні бути передані, цей об'єкт може бути встановлений в нуль.</param>
        /// <returns>
        /// true якщо ця команда може бути виконана; в іншому випадку false.
        /// </returns>
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        /// <summary>
        /// Відбувається, коли зміни відбуваються, які впливають, чи повинен команда виконати.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Визначає метод, який буде викликатися при виклику команди.
        /// </summary>
        /// <param name="parameter">Дані, що використовуються командою. Якщо команда не вимагає дані повинні бути передані, цей об'єкт може бути встановлений в нуль.</param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion ICommand Members
    }
}