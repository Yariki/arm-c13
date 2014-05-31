using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Documents
{
    /// <summary>
    /// Простір імен команд головного меню для документів.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    internal class NamespaceDoc
    {
    }

    /// <summary>
    /// Команда для відкриття журналу контрактів
    /// </summary>
    public class ARMMenuContractCommand : ARMBaseMainMenuCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ARMMenuContractCommand"/> class.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="canPredicate">Предикат.</param>
        public ARMMenuContractCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate)
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.DocumentContract;
            Title = Tooltip = Resource.AppResource.Resources.Model_Contract_Title;
        }

        /// <summary>
        /// Повертає шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected override string GetIconPath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/contract.png";
        }
    }
}