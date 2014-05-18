using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Toolbar
{
    public class ARMToolboxSeparator : ARMBaseMainToolboxCommand
    {
        public ARMToolboxSeparator(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            IsSeparator = true;
        }
    }
}