using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Reference
{
    public class ARMMenuUniversityCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuUniversityCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) 
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceUniversity;
            Title = Tooltip = Resource.AppResource.Resources.Menu_University;
        }
    }
}