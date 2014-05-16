using System;
using ARM.Module.Enums;
using ARM.Resource.AppResource;

namespace ARM.Module.Commands.Menu.Reference
{
    public class ARMMenuFacultyCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuFacultyCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceFaculty;
            Title = Resources.Model_Faculty_Title;
        }
    }
}