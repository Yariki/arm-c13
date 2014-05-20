using ARM.Infrastructure.Events.EventPayload;
using Microsoft.Practices.Prism.Events;

namespace ARM.Infrastructure.Events
{
    /// <summary>
    /// Клас, який визначає подію синхронізації даних.
    /// </summary>
    public class ARMSyncEvent : CompositePresentationEvent<ARMSyncEventPayload>
    {
    }
}