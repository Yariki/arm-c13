using System;
using ARM.Core.Enums;

namespace ARM.Infrastructure.Events.EventPayload
{
  public class ARMViewPayload : ARMBasePayload
  {
    public ARMViewPayload(eARMMetadata metadata,Guid id)
      :base(ViewMode.View,id)
    {
      SetMetadata(metadata);
    }
  }
}