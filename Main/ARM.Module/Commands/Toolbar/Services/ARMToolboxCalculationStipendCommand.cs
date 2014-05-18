using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Toolbar.Services
{
    public class ARMToolboxCalculationStipendCommand : ARMBaseMainToolboxCommand
    {
        public ARMToolboxCalculationStipendCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.ServiceCalculationStipend;
            Tooltip = Resource.AppResource.Resources.Service_CalculationStipend_Title;
        }

        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/calculate.png";
        }
    }
}