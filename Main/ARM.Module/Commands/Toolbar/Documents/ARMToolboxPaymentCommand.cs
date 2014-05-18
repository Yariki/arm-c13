using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Toolbar.Documents
{
    public class ARMToolboxPaymentCommand : ARMBaseMainToolboxCommand
    {
        public ARMToolboxPaymentCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.DocumentPayment;
            Tooltip = Resource.AppResource.Resources.Model_Payment_Title;
        }

        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/payment.png";
        }
    }
}