using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Toolbar.Services
{
    public class ARMToolboxEvalutionCommand : ARMBaseMainToolboxCommand
    {
        public ARMToolboxEvalutionCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.ServiceEvaluation;
            Tooltip = Resource.AppResource.Resources.Service_Evaluation_Title;
        }

        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/mark.png";
        }
    }
}