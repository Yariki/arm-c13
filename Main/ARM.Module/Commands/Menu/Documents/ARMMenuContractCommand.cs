using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Documents
{
    public class ARMMenuContractCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuContractCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) 
            : base(action, canPredicate)
        {
            MenuCommand =   eARMMainMenuCommand.DocumentContract;
            Title = Resource.AppResource.Resources.Model_Contract_Title;
        }
    }
}