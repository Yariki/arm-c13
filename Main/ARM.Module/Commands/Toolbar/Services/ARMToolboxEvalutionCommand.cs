using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Toolbar.Services
{
    /// <summary>
    /// Команда запуску сервісу по внесенню успішності студентів.
    /// </summary>
    public class ARMToolboxEvalutionCommand : ARMBaseMainToolboxCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="predicate">Предикат.</param>
        public ARMToolboxEvalutionCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.ServiceEvaluation;
            Tooltip = Resource.AppResource.Resources.Service_Evaluation_Title;
        }

        /// <summary>
        /// Отримує шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/mark.png";
        }
    }
}