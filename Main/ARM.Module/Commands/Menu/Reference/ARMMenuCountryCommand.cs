using System;
using ARM.Module.Enums;
using ARM.Resource.AppResource;

namespace ARM.Module.Commands.Menu.Reference
{
    public class ARMMenuCountryCommand : ARMBaseMainMenuCommand
    {
        public ARMMenuCountryCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceCountry;
            Title = Resources.Grid_Country_Title;
        }
    }
}