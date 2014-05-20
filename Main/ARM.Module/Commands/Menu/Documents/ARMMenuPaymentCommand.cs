using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Documents
{
    /// <summary>
    /// Команда для відкриття журналу платежів.
    /// </summary>
    public class ARMMenuPaymentCommand : ARMBaseMainMenuCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="canPredicate">Предикат.</param>
        public ARMMenuPaymentCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.DocumentPayment;
            Title = Resource.AppResource.Resources.Model_Payment_Title;
        }

        /// <summary>
        /// Повертає шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected override string GetIconPath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/payment.png";
        }
    }
}