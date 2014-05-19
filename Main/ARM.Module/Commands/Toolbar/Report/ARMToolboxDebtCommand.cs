using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Toolbar.Report
{
    /// <summary>
    /// Команда відкриття форми звіту по заборгованості.
    /// </summary>
    public class ARMToolboxDebtCommand : ARMBaseMainToolboxCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="predicate">Предикат.</param>
        public ARMToolboxDebtCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.ReportDebt;
            Tooltip = Resource.AppResource.Resources.Report_Debt_Title;
        }

        /// <summary>
        /// Отримує шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/bank.png";
        }
    }
}