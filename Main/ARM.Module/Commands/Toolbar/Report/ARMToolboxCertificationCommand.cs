using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Toolbar.Report
{
    public class ARMToolboxCertificationCommand : ARMBaseMainToolboxCommand
    {
        public ARMToolboxCertificationCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.ReportCertification;
            Tooltip = Resource.AppResource.Resources.Report_Certification_Title;
        }

        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/atestation.png";
        }
    }
}