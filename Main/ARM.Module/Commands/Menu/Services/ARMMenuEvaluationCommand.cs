using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Services
{
    public class ARMMenuEvaluationCommand :  ARMBaseMainMenuCommand
    {
        public ARMMenuEvaluationCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) 
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ServiceEvaluation;
            Title = Resource.AppResource.Resources.Service_Evaluation_Title;
        }

        protected override string GetIconPath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/mark.png";
        }

    }
}