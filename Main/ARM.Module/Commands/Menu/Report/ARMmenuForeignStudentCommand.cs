using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Report
{
    public class ARMmenuForeignStudentCommand : ARMBaseMainMenuCommand
    {
        public ARMmenuForeignStudentCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReportForeignStudent;
            Title = Tooltip = Resource.AppResource.Resources.Report_ForeignStudent_Title;
        }
    }
}