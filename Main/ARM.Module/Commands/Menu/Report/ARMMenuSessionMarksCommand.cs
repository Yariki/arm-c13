using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Report
{
    public class ARMMenuSessionMarksCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuSessionMarksCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReportSessionMarks;
            Title = Resource.AppResource.Resources.Report_SessionMark_Title;
        }
    }
}