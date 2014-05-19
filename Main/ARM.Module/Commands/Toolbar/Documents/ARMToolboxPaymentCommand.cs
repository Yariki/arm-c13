using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Toolbar.Documents
{
    /// <summary>
    /// Команда відкриття журналу платежів.
    /// </summary>
    public class ARMToolboxPaymentCommand : ARMBaseMainToolboxCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="predicate">Предикат.</param>
        public ARMToolboxPaymentCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.DocumentPayment;
            Tooltip = Resource.AppResource.Resources.Model_Payment_Title;
        }

        /// <summary>
        /// Отримує шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/payment.png";
        }
    }
}