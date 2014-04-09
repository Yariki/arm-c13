using System;
using ARM.Core.Enums;

namespace ARM.Infrastructure.Events.EventPayload
{
  public class ARMEditEventPayload :  ARMBasePayload
  {
    public ARMEditEventPayload(eARMMetadata metadata,Guid id)
    :base(ViewMode.Edit, id)
    {
      SetMetadata(metadata);
    }

  }
}