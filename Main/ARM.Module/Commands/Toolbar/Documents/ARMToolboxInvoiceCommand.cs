using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Toolbar.Documents
{
    /// <summary>
    /// Команда відкриття журналу рахунків.
    /// </summary>
    public class ARMToolboxInvoiceCommand : ARMBaseMainToolboxCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="predicate">Предикат.</param>
        public ARMToolboxInvoiceCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.DocumentInvoice;
            Tooltip = Resource.AppResource.Resources.Model_Invoice_Title;
        }

        /// <summary>
        /// Отримує шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/invoice.png";
        }
    }
}