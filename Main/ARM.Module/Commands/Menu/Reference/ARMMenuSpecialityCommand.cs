using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Reference
{
    public class ARMMenuSpecialityCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuSpecialityCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceSpeciality;
            Title = Resource.AppResource.Resources.Model_Speciality_Title;
        }
    }
}