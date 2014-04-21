using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Reference
{
    public class ARMMenuStudentCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuStudentCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) 
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceStudent;
            Title = Resource.AppResource.Resources.Model_Student_Title;
        }
    }
}