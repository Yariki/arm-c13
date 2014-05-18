using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Toolbar.Documents
{
    public class ARMToolboxInvoiceCommand : ARMBaseMainToolboxCommand
    {
        public ARMToolboxInvoiceCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.DocumentInvoice;
            Tooltip = Resource.AppResource.Resources.Model_Invoice_Title;
        }

        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/invoice.png";
        }
    }
}