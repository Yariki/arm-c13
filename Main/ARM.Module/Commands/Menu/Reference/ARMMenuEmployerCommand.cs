using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Reference
{
    public class ARMMenuEmployerCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuEmployerCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) 
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceEmployer;
            Title = Resource.AppResource.Resources.Model_Employer_Title;
        }
    }
}