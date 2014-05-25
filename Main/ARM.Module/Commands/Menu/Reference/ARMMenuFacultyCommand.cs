using System;
using ARM.Module.Enums;
using ARM.Resource.AppResource;

namespace ARM.Module.Commands.Menu.Reference
{
    /// <summary>
    /// Команда відкриття журналу факультетів.
    /// </summary>
    public class ARMMenuFacultyCommand : ARMBaseMainMenuCommand
    {
        /// <summary>
        /// Сворення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="canPredicate">Предикат.</param>
        public ARMMenuFacultyCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceFaculty;
            Title = Tooltip = Resources.Model_Faculty_Title;
        }
    }
}