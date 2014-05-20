using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Report
{
    /// <summary>
    /// Команда відкриття форми звіту по атестаціям.
    /// </summary>
    public class ARMMenuCertificationCommand : ARMBaseMainMenuCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="canPredicate">Предикат.</param>
        public ARMMenuCertificationCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReportCertification;
            Title = Resource.AppResource.Resources.Report_Certification_Title;
        }

        /// <summary>
        /// Повертає шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected override string GetIconPath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/atestation.png";
        }
    }
}