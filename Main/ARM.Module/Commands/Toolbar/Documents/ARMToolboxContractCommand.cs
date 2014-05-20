 using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Toolbar.Documents
{
    /// <summary>
    /// Команда дял відкриття журналу контрактів
    /// </summary>
    public class ARMToolboxContractCommand :  ARMBaseMainToolboxCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="predicate">Предикат.</param>
        public ARMToolboxContractCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.DocumentContract;
            Tooltip = Resource.AppResource.Resources.Model_Contract_Title;
        }

        /// <summary>
        /// Отримує шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/contract.png";
        }
    }
}