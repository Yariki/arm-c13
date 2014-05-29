using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Report
{
    /// <summary>
    /// Команда для відкриття звіту який формує списки сьудентів, що поновлюються.
    /// </summary>
    public class ARMMenuRenewCommand : ARMBaseMainMenuCommand
    {
        /// <summary>
        /// Ініціалізіція нового екземпляра  <see cref="ARMMenuRenewCommand"/>.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="canPredicate">Предикат.</param>
        public ARMMenuRenewCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReportRenew;
            Title = Tooltip = Resource.AppResource.Resources.Report_Renew_Title;
        }
    }
}