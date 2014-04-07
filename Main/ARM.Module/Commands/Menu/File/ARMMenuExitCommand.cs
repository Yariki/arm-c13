using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.File
{
    public class ARMMenuExitCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuExitCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) 
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.Exit;
            Title = Tooltip = Resource.AppResource.Resources.Menu_Exit;
        }
    }
}