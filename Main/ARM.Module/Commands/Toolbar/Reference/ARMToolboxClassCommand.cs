using System;
using ARM.Module.Enums;
using ARM.Resource.AppResource;

namespace ARM.Module.Commands.Toolbar.Reference
{
    /// <summary>
    /// Команда відкриття журналу занятть.
    /// </summary>
    public class ARMToolboxClassCommand : ARMBaseMainToolboxCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="predicate">Предикат.</param>
        public ARMToolboxClassCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.ReferenceClass;
            Tooltip = Resources.Model_Class_Title;
        }

        /// <summary>
        /// Отримує шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/appointment.png";
        }
    }
}