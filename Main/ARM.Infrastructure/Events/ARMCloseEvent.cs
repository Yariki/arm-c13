using ARM.Infrastructure.Events.EventPayload;
using Microsoft.Practices.Prism.Events;

namespace ARM.Infrastructure.Events
{
    /// <summary>
    /// Класс, який визначає подію закриття
    /// </summary>
    public class ARMCloseEvent : CompositePresentationEvent<ARMCloseEventPayload>
    {
    }
}