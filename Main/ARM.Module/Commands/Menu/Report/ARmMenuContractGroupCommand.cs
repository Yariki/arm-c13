using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Report
{
    /// <summary>
    /// Команда відкриття форми звіту по контрактам групи.
    /// </summary>
    public class ARMMenuContractGroupCommand : ARMBaseMainMenuCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="canPredicate">Предикат.</param>
        public ARMMenuContractGroupCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReportContractGroup;
            Title = Resource.AppResource.Resources.Report_ContractGroup_Title;
        }
    }
}