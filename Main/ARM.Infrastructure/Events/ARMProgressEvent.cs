using ARM.Infrastructure.Events.EventPayload;
using Microsoft.Practices.Prism.Events;

namespace ARM.Infrastructure.Events
{
    /// <summary>
    /// Клас події, яка сповіщає про значення прогрусу тривалої операції.
    /// </summary>
    public class ARMProgressEvent : CompositePresentationEvent<ARMProgressEventPayload>
    {    
    }
}