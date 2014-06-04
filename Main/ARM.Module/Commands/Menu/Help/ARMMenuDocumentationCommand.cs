using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Help
{
    public class ARMMenuDocumentationCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuDocumentationCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.HelpDocumentation;
            Title = Tooltip = Resource.AppResource.Resources.Help_Documentation_Title;
        }
    }
}