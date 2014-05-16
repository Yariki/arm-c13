using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Services
{
    public class ARMMenuCalculationStipendCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuCalculationStipendCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ServiceCalculationStipend;
            Title = Resource.AppResource.Resources.Service_CalculationStipend_Title;
        }
    }
}