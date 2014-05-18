using System;
using ARM.Module.Enums;
using ARM.Resource.AppResource;

namespace ARM.Module.Commands.Menu.File
{
    public class ARMMenuExitCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuExitCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.Exit;
            Title = Tooltip = Resources.Menu_Exit;
        }

        protected override string GetIconPath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/exit.png";
        }
    }
}