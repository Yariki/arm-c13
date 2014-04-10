using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Reference
{
    public class ARMMenuStaffCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuStaffCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) 
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceStaff;
            Title = Resource.AppResource.Resources.Grid_Staff_Title;
        }
    }
}