/*
 * Created by SharpDevelop.
 * User: QAPUSER
 * Date: 09.04.2014
 * Time: 12:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ARM.Core.Enums;

namespace ARM.Infrastructure.Events.EventPayload
{
	/// <summary>
	/// Description of ARMAddEventPayload.
	/// </summary>
	public class ARMAddEventPayload : ARMBasePayload
	{
		public ARMAddEventPayload(eARMMetadata metadata)
			:base(ViewMode.Add,Guid.Empty)
		{
			SetMetadata(metadata);
		}
	}
}
