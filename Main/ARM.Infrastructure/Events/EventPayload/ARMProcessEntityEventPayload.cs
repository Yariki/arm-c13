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
    /// Класс для події, яка викликається при здійсненні певної дії над моделю даних.
    /// </summary>
    public class ARMProcessEntityEventPayload : ARMBasePayload
    {
        /// <summary>
        /// Ініціалізує новий екземпляр класу <see cref="ARMProcessEntityEventPayload"/>.
        /// </summary>
        /// <param name="metadata">Метадата.</param>
        /// <param name="mode">Режим.</param>
        /// <param name="id">Ідентифікатор.</param>
        public ARMProcessEntityEventPayload(eARMMetadata metadata, ViewMode mode, Guid id)
            : base(mode, id)
        {
            SetMetadata(metadata);
        }
    }
}