/*
 * Created by SharpDevelop.
 * User: QAPUSER
 * Date: 09.04.2014
 * Time: 12:33
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using ARM.Core.Enums;

namespace ARM.Infrastructure.Events.EventPayload
{
    /// <summary>
    ///     Description of ARMBaserPayload.
    /// </summary>
    public abstract class ARMBasePayload
    {
        protected ARMBasePayload(ViewMode mode, Guid id)
        {
            Mode = mode;
            Id = id;
        }

        public ViewMode Mode { get; protected set; }

        public eARMMetadata Metadata { get; protected set; }

        public Guid Id { get; protected set; }

        protected void SetMetadata(eARMMetadata metadata)
        {
            Metadata = metadata;
        }
    }
}