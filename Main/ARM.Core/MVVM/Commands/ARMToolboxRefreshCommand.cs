using System;
using ARM.Core.Enums;
using ARM.Core.MVVM.Commands.Base;

namespace ARM.Core.MVVM.Commands
{
    /// <summary>
    /// Класс, що зумовлює оновлення даних в сітці.
    /// </summary>
    public class ARMToolboxRefreshCommand : ARMToolboxCommandBase
    {
        /// <summary>
        /// Створити екземпляр ARMToolboxRefreshCommand.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="predicate">Предикат.</param>
        public ARMToolboxRefreshCommand(Action<ToolbarCommand> action, Func<ToolbarCommand, bool> predicate) : base(action, predicate)
        {
            Type = ToolbarCommand.Refresh;
            Title = Resource.AppResource.Resources.UI_Refresh;
        }

        /// <summary>
        /// Створити екземпляр ARMToolboxRefreshCommand.
        /// </summary>
        /// <param name="action">Дія.</param>
        public ARMToolboxRefreshCommand(Action<ToolbarCommand> action) : this(action,null)
        {
        }

        /// <summary>
        /// Визначає порядок.
        /// </summary>
        /// <returns></returns>
        protected override int GetOrder()
        {
            return 3;
        }

        /// <summary>
        /// Gets the image path.
        /// </summary>
        /// <returns></returns>
        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/data-refresh-icon.png";
        }
    }
}