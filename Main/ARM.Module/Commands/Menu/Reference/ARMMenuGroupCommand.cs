using System;
using ARM.Module.Enums;
using ARM.Resource.AppResource;

namespace ARM.Module.Commands.Menu.Reference
{
    public class ARMMenuGroupCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuGroupCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceGroup;
            Title = Resources.Model_Group_Title;
        }
    }
}