using System;
using ARM.Core.Enums;
using ARM.Core.Interfaces;

namespace ARM.Infrastructure.Events.EventPayload
{
    public class ARMCloseEventPayload : ARMBasePayload
    {
        public ARMCloseEventPayload(IARMWorkspaceViewModel model)
            : base(ViewMode.None, Guid.Empty)
        {
            Model = model;
        }

        public IARMWorkspaceViewModel Model { get; private set; }
    }
}