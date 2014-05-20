using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Toolbar
{
    /// <summary>
    /// Команда, яка вистпає роздільником на панелі управління.
    /// </summary>
    public class ARMToolboxSeparator : ARMBaseMainToolboxCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="predicate">Предикат.</param>
        public ARMToolboxSeparator(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            IsSeparator = true;
        }
    }
}