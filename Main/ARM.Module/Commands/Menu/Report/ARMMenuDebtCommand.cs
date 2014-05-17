using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Report
{
    /// <summary>
    /// Команда для запуску звіту по заборгованості.
    /// Відображає головну форму звіту.
    /// </summary>
    public class ARMMenuDebtCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuDebtCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) 
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReportDebt;
            Title = Resource.AppResource.Resources.Report_Debt_Title;
        }
    }
}