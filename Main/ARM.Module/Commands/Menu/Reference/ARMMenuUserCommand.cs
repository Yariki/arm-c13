using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Reference
{
    public class ARMMenuUserCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuUserCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) 
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceUser;
            Title = Resource.AppResource.Resources.Model_User_Title;
        }
    }
}