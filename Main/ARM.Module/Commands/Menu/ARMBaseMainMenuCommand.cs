using System;
using ARM.Module.Enums;
using ARM.Module.Interfaces;

namespace ARM.Module.Commands.Menu
{
    public abstract class ARMBaseMainMenuCommand : IARMMenuCommand
    {
        private readonly Action<eARMMainMenuCommand> _action;
        private readonly Func<eARMMainMenuCommand, bool> _canExecute;

        protected ARMBaseMainMenuCommand(Action<eARMMainMenuCommand> action,
            Func<eARMMainMenuCommand, bool> canPredicate)
        {
            _action = action;
            _canExecute = canPredicate;
        }

        #region IARMMenuCommand Members

        public void Execute(object parameter)
        {
            if (_action != null)
            {
                _action(MenuCommand);
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(MenuCommand);
        }

        public event EventHandler CanExecuteChanged;

        public string Title { get; set; }

        public string Tooltip { get; set; }

        public eARMMainMenuCommand MenuCommand { get; protected set; }

        #endregion IARMMenuCommand Members
    }
}