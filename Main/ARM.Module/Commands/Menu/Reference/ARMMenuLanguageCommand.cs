using System;
using ARM.Module.Enums;
using ARM.Resource.AppResource;

namespace ARM.Module.Commands.Menu.Reference
{
    public class ARMMenuLanguageCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuLanguageCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceLanguage;
            Title = Resources.Grid_Language_Title;
        }
    }
}