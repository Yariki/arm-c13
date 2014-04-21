using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Reference
{
    public class ARMMenuLanguageCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuLanguageCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceLanguage;
            Title = Resource.AppResource.Resources.Grid_Language_Title;
        }
    }
}