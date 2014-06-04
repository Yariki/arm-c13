using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Help
{
    public class ARMMenuAboutCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuAboutCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.HelpAbout;
            Title = Tooltip = Resource.AppResource.Resources.Help_About_Title;
        }
    }
}