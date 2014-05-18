using System;
using ARM.Module.Enums;
using ARM.Resource.AppResource;

namespace ARM.Module.Commands.Menu.Reference
{
    public class ARMMenuUserCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuUserCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceUser;
            Title = Resources.Model_User_Title;
        }

        protected override string GetIconPath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/user.png";
        }
    }
}