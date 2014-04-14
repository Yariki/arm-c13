﻿using System;
using ARM.Module.Enums;
using ARM.Module.Interfaces;

namespace ARM.Module.Commands.Menu
{
    public abstract class ARMBaseMainMenuCommand : IARMMenuCommand
    {
        private Action<eARMMainMenuCommand> _action;
        private Func<eARMMainMenuCommand, bool> _canExecute;

        protected ARMBaseMainMenuCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
        {
            _action = action;
            _canExecute = canPredicate;
        }

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
    }
}