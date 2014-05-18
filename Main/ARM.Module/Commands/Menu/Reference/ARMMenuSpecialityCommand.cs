using System;
using ARM.Module.Enums;
using ARM.Resource.AppResource;

namespace ARM.Module.Commands.Menu.Reference
{
    public class ARMMenuSpecialityCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuSpecialityCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceSpeciality;
            Title = Resources.Model_Speciality_Title;
        }

        protected override string GetIconPath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/briefcase.png";
        }
    }
}