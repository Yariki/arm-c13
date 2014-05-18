using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Toolbar.Reference
{
    public class ARMToolboxAddressCommand : ARMBaseMainToolboxCommand
    {
        public ARMToolboxAddressCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.ReferenceAddress;
            Tooltip = Resource.AppResource.Resources.Model_Address_Title;
        }

        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/home.png";
        }
    }
}