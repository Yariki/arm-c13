using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Reference
{
    public class ARMMenuClassCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuClassCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) 
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceClass;
            Title = Resource.AppResource.Resources.Model_Class_Title;
        }
    }
}