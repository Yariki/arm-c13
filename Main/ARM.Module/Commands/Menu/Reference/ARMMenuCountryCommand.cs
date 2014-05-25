using System;
using ARM.Module.Enums;
using ARM.Resource.AppResource;

namespace ARM.Module.Commands.Menu.Reference
{
    /// <summary>
    /// Команда відкриття журналу країн.
    /// </summary>
    public class ARMMenuCountryCommand : ARMBaseMainMenuCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="canPredicate">Предикат.</param>
        public ARMMenuCountryCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceCountry;
            Title = Tooltip = Resources.Grid_Country_Title;
        }

        /// <summary>
        /// Повертає шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected override string GetIconPath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/globe.png";
        }
    }
}