using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Reference
{
    public class ARMMenuAddressCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuAddressCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceAddress;
            Title = Resource.AppResource.Resources.Model_Address_Title;
        }
    }
}