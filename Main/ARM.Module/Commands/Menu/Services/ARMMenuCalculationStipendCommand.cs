using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Services
{
    /// <summary>
    /// Команда запуску сервісу для розрахунку стипендій.
    /// </summary>
    public class ARMMenuCalculationStipendCommand : ARMBaseMainMenuCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="canPredicate">Предикат.</param>
        public ARMMenuCalculationStipendCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ServiceCalculationStipend;
            Title = Resource.AppResource.Resources.Service_CalculationStipend_Title;
        }

        /// <summary>
        /// Повертає шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected override string GetIconPath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/calculate.png";
        }
    }
}