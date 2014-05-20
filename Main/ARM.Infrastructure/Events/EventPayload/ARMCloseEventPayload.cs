using System;
using ARM.Core.Enums;
using ARM.Core.Interfaces;

namespace ARM.Infrastructure.Events.EventPayload
{
    /// <summary>
    /// Класс для події закриття моделі.
    /// </summary>
    public class ARMCloseEventPayload : ARMBasePayload
    {
        /// <summary>
        /// Ініціалізує новий екземпляр класу <see cref="ARMCloseEventPayload"/>.
        /// </summary>
        /// <param name="model">Модель.</param>
        public ARMCloseEventPayload(IARMWorkspaceViewModel model)
            : base(ViewMode.None, Guid.Empty)
        {
            Model = model;
        }

        /// <summary>
        /// отримує модель, яку потрібно закрити.
        /// </summary>
        public IARMWorkspaceViewModel Model { get; private set; }
    }
}