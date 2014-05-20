using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Toolbar.Reference
{
    /// <summary>
    /// Команда відкриття журналу адрес.
    /// </summary>
    public class ARMToolboxAddressCommand : ARMBaseMainToolboxCommand
    {
        /// <summary>
        /// Створення нового екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="predicate">Предикат.</param>
        public ARMToolboxAddressCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.ReferenceAddress;
            Tooltip = Resource.AppResource.Resources.Model_Address_Title;
        }

        /// <summary>
        /// Отримує шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/home.png";
        }
    }
}