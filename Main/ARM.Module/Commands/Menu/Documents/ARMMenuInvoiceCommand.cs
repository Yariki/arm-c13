using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Documents
{
    /// <summary>
    /// Команда для відкриття журналу рахунків.
    /// </summary>
    public class ARMMenuInvoiceCommand : ARMBaseMainMenuCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="canPredicate">Предикат.</param>
        public ARMMenuInvoiceCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.DocumentInvoice;
            Title = Tooltip = Resource.AppResource.Resources.Model_Invoice_Title;
        }

        /// <summary>
        /// Повертає шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected override string GetIconPath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/invoice.png";
        }

    }
}