using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Report
{
    /// <summary>
    /// Команда для запуску форми звіту для академічної заборгованості.
    /// </summary>
    public class ARMMenuAcademicArrearsCommand : ARMBaseMainMenuCommand
    {
        /// <summary>
        /// Створити екземпляр ARMMenuAcademicArrearsCommand.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="canPredicate">Предикат.</param>
        public ARMMenuAcademicArrearsCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReportAcademicArrears;
            Title = Tooltip = Resource.AppResource.Resources.Report_AcademicArrears_Title;
        }
    }
}