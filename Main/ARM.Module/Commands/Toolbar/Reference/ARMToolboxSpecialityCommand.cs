using System;
using ARM.Module.Enums;
using ARM.Resource.AppResource;

namespace ARM.Module.Commands.Toolbar.Reference
{
    /// <summary>
    /// Команда відкриття журналу спеціальностей.
    /// </summary>
    public class ARMToolboxSpecialityCommand :  ARMBaseMainToolboxCommand
    {
        /// <summary>
        /// Створення екземплялру.
        /// </summary>
        /// <param name="action">Дія.</param>
        /// <param name="predicate">Предикат.</param>
        public ARMToolboxSpecialityCommand(Action<eARMMainMenuCommand> action, Func<eARMMainMenuCommand, bool> predicate) : base(action, predicate)
        {
            ToolbarCommand = eARMMainMenuCommand.ReferenceSpeciality;
            Tooltip = Resources.Model_Speciality_Title;
        }

        /// <summary>
        /// Отримує шлях до іконки.
        /// </summary>
        /// <returns></returns>
        protected override string GetImagePath()
        {
            return @"pack://application:,,,/ARM.Resource;component/Images/briefcase.png";
        }
    }
}