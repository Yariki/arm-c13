using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Report
{
    public class ARMMenuCertificationCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuCertificationCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReportCertification;
            Title = Resource.AppResource.Resources.Report_Certification_Title;
        }

        protected override string GetIconPath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/atestation.png";
        }
    }
}