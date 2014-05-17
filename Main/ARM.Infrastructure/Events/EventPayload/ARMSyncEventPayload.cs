using System;
using ARM.Core.Enums;

namespace ARM.Infrastructure.Events.EventPayload
{
    /// <summary>
    /// Класс для події синхроніхації даних.
    /// </summary>
    public class ARMSyncEventPayload : ARMBasePayload
    {
        /// <summary>
        /// Ініціалізує новий екземпляр класу <see cref="ARMSyncEventPayload"/>.
        /// </summary>
        /// <param name="metadata">Метадата.</param>
        public ARMSyncEventPayload(eARMMetadata metadata)
            : base(ViewMode.None, Guid.Empty)
        {
            SetMetadata(metadata);
        }
    }
}