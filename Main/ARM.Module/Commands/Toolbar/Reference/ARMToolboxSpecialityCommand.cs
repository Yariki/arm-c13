using System;
using ARM.Module.Enums;
using ARM.Resource.AppResource;

namespace ARM.Module.Commands.Toolbar.Reference
{
    public class ARMToolboxSpecialityCommand :  ARMBaseMainToolboxCommand
    {
        public ARMToolboxSpecialityCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.ReferenceSpeciality;
            Tooltip = Resources.Model_Speciality_Title;
        }

        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/briefcase.png";
        }
    }
}