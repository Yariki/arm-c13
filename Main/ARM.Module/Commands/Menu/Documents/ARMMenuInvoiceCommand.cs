using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Documents
{
    public class ARMMenuInvoiceCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuInvoiceCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) 
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.DocumentInvoice;
            Title = Resource.AppResource.Resources.Model_Invoice_Title;
        }
    }
}