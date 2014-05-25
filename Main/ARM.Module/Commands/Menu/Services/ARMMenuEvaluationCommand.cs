using System;
using ARM.Module.Enums;

namespace ARM.Module.Commands.Menu.Services
{
    /// <summary>
    /// Команда запуску сервісу для внесення успішності студентів по предметам.
    /// </summary>
    public class ARMMenuEvaluationCommand :  ARMBaseMainMenuCommand
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="canPredicate">Предикат.</param>
        public ARMMenuEvaluationCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> canPredicate) 
            : base(action, canPredicate)
        {
            MenuCommand = eARMMainMenuCommand.ServiceEvaluation;
            Title = Tooltip = Resource.AppResource.Resources.Service_Evaluation_Title;
        }

        /// <summary>
        /// Повертає шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected override string GetIconPath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/mark.png";
        }

    }
}