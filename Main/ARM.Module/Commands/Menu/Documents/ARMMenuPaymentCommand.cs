using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Documents
{
    public class ARMMenuPaymentCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuPaymentCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) 
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.DocumentPayment;
            Title = Resource.AppResource.Resources.Model_Payment_Title;
        }
    }
}