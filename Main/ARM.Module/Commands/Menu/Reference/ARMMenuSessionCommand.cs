using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Reference
{
    public class ARMMenuSessionCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuSessionCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceSession;
            Title = Resource.AppResource.Resources.Model_Session_Title;
        }
    }
}