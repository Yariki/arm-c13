using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Toolbar.Documents
{
    public class ARMToolboxContractCommand :  ARMBaseMainToolboxCommand
    {
        public ARMToolboxContractCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.DocumentContract;
            Tooltip = Resource.AppResource.Resources.Model_Contract_Title;
        }

        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/contract.png";
        }
    }
}