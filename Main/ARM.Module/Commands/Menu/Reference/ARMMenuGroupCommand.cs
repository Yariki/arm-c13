using System;
using ARM.Module.Enums;
using ARM.Resource.AppResource;

namespace ARM.Module.Commands.Menu.Reference
{
    /// <summary>
    /// Команда відкриття журналу груп.
    /// </summary>
    public class ARMMenuGroupCommand : ARMBaseMainMenuCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="canPredicate">Предикат.</param>
        public ARMMenuGroupCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceGroup;
            Title = Tooltip = Resources.Model_Group_Title;
        }

        /// <summary>
        /// Повертає шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected override string GetIconPath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/group.png";
        }
    }
}