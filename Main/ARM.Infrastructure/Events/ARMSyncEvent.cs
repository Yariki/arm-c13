﻿using ARM.Infrastructure.Events.EventPayload;
using Microsoft.Practices.Prism.Events;

namespace ARM.Infrastructure.Events
{
    public class ARMSyncEvent : CompositePresentationEvent<ARMSyncEventPayload>
    {
    }
}