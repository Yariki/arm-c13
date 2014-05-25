using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Reference
{
    /// <summary>
    /// Команда відкриття журналу студентів.
    /// </summary>
    public class ARMMenuStudentCommand : ARMBaseMainMenuCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="canPredicate">Предикат.</param>
        public ARMMenuStudentCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceStudent;
            Title = Tooltip = Resource.AppResource.Resources.Model_Student_Title;
        }

        /// <summary>
        /// Повертає шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected override string GetIconPath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/graduated-icon.png";
        }
    }
}