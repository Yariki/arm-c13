using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Toolbar.Services
{
    /// <summary>
    /// Команда запуску сервісу розрахунку стипендій.
    /// </summary>
    public class ARMToolboxCalculationStipendCommand : ARMBaseMainToolboxCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="predicate">Предикат.</param>
        public ARMToolboxCalculationStipendCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.ServiceCalculationStipend;
            Tooltip = Resource.AppResource.Resources.Service_CalculationStipend_Title;
        }

        /// <summary>
        /// Отримує шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/calculate.png";
        }
    }
}