using System;
using ARM.Module.Enums;
using ARM.Resource.AppResource;

namespace ARM.Module.Commands.Toolbar.Reference
{
    public class ARMToolboxClassCommand : ARMBaseMainToolboxCommand
    {
        public ARMToolboxClassCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.ReferenceClass;
            Tooltip = Resources.Model_Class_Title;
        }

        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/appointment.png";
        }
    }
}