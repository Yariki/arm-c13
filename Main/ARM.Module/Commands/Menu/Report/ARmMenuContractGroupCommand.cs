using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Report
{
    public class ARMMenuContractGroupCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuContractGroupCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) 
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReportContractGroup;
            Title = Resource.AppResource.Resources.Report_ContractGroup_Title;
        }
    }
}