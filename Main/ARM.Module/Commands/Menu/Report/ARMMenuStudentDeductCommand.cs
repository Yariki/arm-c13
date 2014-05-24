using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Report
{
    /// <summary>
    /// Команда для визову звіту для виводу списку студентів на відрахування.
    /// </summary>
    public class ARMMenuStudentDeductCommand : ARMBaseMainMenuCommand
    {
        /// <summary>
        /// Створити екземпляр ARMMenuStudentDeductCommand.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="canPredicate">Предикат.</param>
        public ARMMenuStudentDeductCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) 
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReportDeduct;
            Title = Tooltip = Resource.AppResource.Resources.Report_Deduct_Title;
        }
    }
}