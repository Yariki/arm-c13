using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Toolbar.Report
{
    /// <summary>
    /// Команда відкриття форми звіту по атестаціям.
    /// </summary>
    public class ARMToolboxCertificationCommand : ARMBaseMainToolboxCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="predicate">Предикат.</param>
        public ARMToolboxCertificationCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.ReportCertification;
            Tooltip = Resource.AppResource.Resources.Report_Certification_Title;
        }

        /// <summary>
        /// Отримує шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/atestation.png";
        }
    }
}