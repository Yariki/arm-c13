using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Toolbar.Report
{
    public class ARMToolboxDebtCommand : ARMBaseMainToolboxCommand
    {
        public ARMToolboxDebtCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.ReportDebt;
            Tooltip = Resource.AppResource.Resources.Report_Debt_Title;
        }

        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/bank.png";
        }
    }
}