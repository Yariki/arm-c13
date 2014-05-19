using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Report
{
    /// <summary>
    /// Команда відкриття форми звіту по студентам-іноземцям.
    /// </summary>
    public class ARMMenuForeignStudentCommand : ARMBaseMainMenuCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="canPredicate">Предикат.</param>
        public ARMMenuForeignStudentCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReportForeignStudent;
            Title = Tooltip = Resource.AppResource.Resources.Report_ForeignStudent_Title;
        }
    }
}