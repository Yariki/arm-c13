using System;
using ARM.Core.Enums;
using ARM.Module.Enums;
using ARM.Module.Interfaces;

namespace ARM.Module.Commands.Toolbar
{
    public abstract class ARMBaseMainToolboxCommand : IARMMainToolboxCommand
    {
        private Action<eARMMainMenuCommand> _action;
        private Func<eARMMainMenuCommand, bool> _predicate;


        protected ARMBaseMainToolboxCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand,bool> predicate )
        {
            _action = action;
            _predicate = predicate;
        }

        public void Execute(object parameter)
        {
            if (_action != null)
            {
                _action(ToolbarCommand);
            }
        }

        public bool CanExecute(object parameter)
        {
            return _predicate != null && _predicate(ToolbarCommand);
        }

        public event EventHandler CanExecuteChanged;
        public string Title { get; protected set; }
        public string Image 
        {
            get { return GetImagePath(); }
        }
        public string ResourceName { get; protected set; }
        public string Tooltip { get; protected set; }
        public object Tag { get; protected set; }
        public ToolbarCommand Type { get; private set; }
        public int Order { get; protected set; }
        public eARMMainMenuCommand ToolbarCommand { get; protected set; }
        public bool IsSeparator { get; protected set; }

        protected virtual string GetImagePath()
        {
            return string.Empty;
        }
    }
}