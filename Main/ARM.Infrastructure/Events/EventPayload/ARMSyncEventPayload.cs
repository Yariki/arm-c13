using System;
using ARM.Core.Enums;

namespace ARM.Infrastructure.Events.EventPayload
{
    public class ARMSyncEventPayload : ARMBasePayload
    {
        public ARMSyncEventPayload(eARMMetadata metadata)
            : base(ViewMode.None, Guid.Empty)
        {
            SetMetadata(metadata);
        }
    }
}