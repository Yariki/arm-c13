using System;
using ARM.Module.Enums;
using ARM.Resource.AppResource;

namespace ARM.Module.Commands.Menu.Reference
{
    public class ARMMenuClassCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuClassCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceClass;
            Title = Resources.Model_Class_Title;
        }

        protected override string GetIconPath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/appointment.png";
        }
    }
}