using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Reference
{
    public class ARMMenuFacultyCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuFacultyCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceFaculty;
            Title = Resource.AppResource.Resources.Model_Faculty_Title;
        }
    }
}