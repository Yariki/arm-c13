using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Toolbar.Reference
{
    /// <summary>
    /// Команда відкриття журналу  стидентів.
    /// </summary>
    public class ARMToolboxStudentCommand : ARMBaseMainToolboxCommand
    {
        /// <summary>
        /// Створення екземплляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="predicate">Предикат.</param>
        public ARMToolboxStudentCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) 
            : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.ReferenceStudent;
            Tooltip = Title = Resource.AppResource.Resources.Model_Student_Title;
        }

        /// <summary>
        /// Отримує шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/graduated-icon.png";
        }
    }
}