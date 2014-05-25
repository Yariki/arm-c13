using ARM.Infrastructure.Events.EventPayload;
using Microsoft.Practices.Prism.Events;

namespace ARM.Infrastructure.Events
{
    /// <summary>
    /// Клас події, що призводить до очищення прогресу тривалого процесу.
    /// </summary>
    public class ARMClearProgressEvent : CompositePresentationEvent<ARMClearProgressEventPayload>
    {    
    }
}