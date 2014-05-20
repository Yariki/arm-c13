
using ARM.Infrastructure.Events.EventPayload;
using Microsoft.Practices.Prism.Events;

namespace ARM.Infrastructure.Events
{
    /// <summary>
    /// Клас, який визначає подію обробки моделі даних.
    /// </summary>
    public class ARMEntityProcessEvent : CompositePresentationEvent<ARMProcessEntityEventPayload>
    {
    }
}