using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Report
{
    /// <summary>
    /// Команда відкриття форми звіту по результатам за семестр.
    /// </summary>
    public class ARMMenuSessionMarksCommand : ARMBaseMainMenuCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="canPredicate">Предикат.</param>
        public ARMMenuSessionMarksCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReportSessionMarks;
            Title = Resource.AppResource.Resources.Report_SessionMark_Title;
        }
    }
}