using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Core.MVVM.Commands;

namespace ARM.Core.MVVM
{
    /// <summary>
    ///     базовий класс для панелей управління
    /// </summary>
    public class ARMToolboxBase : ARMViewModelBase, IARMToolboxViewModel
    {
        /// <summary>
        ///     внутрішній список команд
        /// </summary>
        protected readonly ObservableCollection<IARMToolboxCommand> CmdList =
            new ObservableCollection<IARMToolboxCommand>();

        /// <summary>
        ///     внутрішня команда, котра викликається при натисканні на кнопку
        /// </summary>
        protected Action<ToolbarCommand> InternalAction;

        /// <summary>
        ///     внутрішній предикат команди. Відповідає до доступність кнопки
        /// </summary>
        protected Func<ToolbarCommand, bool> InternalPredicate;

        /// <summary>
        ///     створює екземпляр класу
        /// </summary>
        /// <param name="view">модель користувацього інтерфейсу</param>
        public ARMToolboxBase(IARMToolboxView view)
            : base(view)
        {
        }

        #region IARMToolboxViewModel Members

        /// <summary>
        ///     відсортований списко команд
        /// </summary>
        /// <value>
        ///     The commands.
        /// </value>
        public IEnumerable<IARMToolboxCommand> Commands
        {
            get { return CmdList.OrderBy(c => c.Order).AsEnumerable(); }
        }

        public void InitializeCommands()
        {
            InternalInitialize();
        }

        /// <summary>
        ///     додати команду
        /// </summary>
        /// <param name="cmd">Команда.</param>
        public void AddCommand(IARMToolboxCommand cmd)
        {
            CmdList.Add(cmd);
            OnPropertyChanged(() => Commands);
        }

        /// <summary>
        ///     Встановити обробники натиску кнопок і предикат
        /// </summary>
        /// <param name="action">Метод</param>
        /// <param name="predicate">Предикат</param>
        public void SetActions(Action<ToolbarCommand> action, Func<ToolbarCommand, bool> predicate)
        {
            InternalAction = action;
            InternalPredicate = predicate;
        }

        #endregion IARMToolboxViewModel Members

        /// <summary>
        ///     метод ініціалізації панелі
        /// </summary>
        protected virtual void InternalInitialize()
        {
            CmdList.Add(new ARMToolboxAddCommand(InternalAction, InternalPredicate));
            CmdList.Add(new ARMToolboxEditCommand(InternalAction, InternalPredicate));
            CmdList.Add(new ARMToolboxDeleteCommand(InternalAction, InternalPredicate));
            CmdList.Add(new ARMToolboxRefreshCommand(InternalAction,InternalPredicate));
        }
    }
}