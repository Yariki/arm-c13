using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Reference
{
    public class ARMMenuSettingsCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuSettingsCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) 
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceSettings;
            Title = Resource.AppResource.Resources.Model_Settings_Title;
        }
    }
}