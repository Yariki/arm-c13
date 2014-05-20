using System;
using ARM.Module.Enums;
using ARM.Resource.AppResource;

namespace ARM.Module.Commands.Menu.Reference
{
    /// <summary>
    /// Команда відкриття форми налаштувань.
    /// </summary>
    public class ARMMenuSettingsCommand : ARMBaseMainMenuCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="canPredicate">Предикат.</param>
        public ARMMenuSettingsCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ReferenceSettings;
            Title = Resources.Model_Settings_Title;
        }

        /// <summary>
        /// Повертає шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected override string GetIconPath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/gear.png";
        }
    }
}