using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Reference
{
    /// <summary>
    /// Команда відкриття журналу роботодавців.
    /// </summary>
    public class ARMMenuEmployerCommand : ARMBaseMainMenuCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="canPredicate">Предикат.</param>
        public ARMMenuEmployerCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceEmployer;
            Title = Tooltip = Resource.AppResource.Resources.Model_Employer_Title;
        }
    }
}