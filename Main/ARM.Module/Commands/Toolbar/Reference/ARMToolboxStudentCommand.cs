using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Toolbar.Reference
{
    public class ARMToolboxStudentCommand : ARMBaseMainToolboxCommand
    {
        public ARMToolboxStudentCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) 
            : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.ReferenceStudent;
            Tooltip = Title = Resource.AppResource.Resources.Model_Student_Title;
        }

        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/graduated-icon.png";
        }
    }
}