/*
 * Created by SharpDevelop.
 * User: QAPUSER
 * Date: 09.04.2014
 * Time: 12:30
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using ARM.Infrastructure.Events.EventPayload;
using Microsoft.Practices.Prism.Events;

namespace ARM.Infrastructure.Events
{
    /// <summary>
    /// Description of ARMEntityAddEvent.
    /// </summary>
    public class ARMEntityProcessEvent : CompositePresentationEvent<ARMProcessEntityEventPayload>
    {
    }
}