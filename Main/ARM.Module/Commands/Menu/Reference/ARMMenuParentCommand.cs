using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Reference
{
    public class ARMMenuParentCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuParentCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceParent;
            Title = Resource.AppResource.Resources.Model_Parent_Title;
        }
    }
}