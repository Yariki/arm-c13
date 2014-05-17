
using System;
using ARM.Core.Enums;

namespace ARM.Infrastructure.Events.EventPayload
{
    /// <summary>
    /// Базовий клас для аргументів подій.
    /// </summary>
    public abstract class ARMBasePayload
    {
        /// <summary>
        /// Ініціалізує новий екземпляр класу <see cref="ARMBasePayload"/>.
        /// </summary>
        /// <param name="mode">Режиим.</param>
        /// <param name="id">Ідентификатор.</param>
        protected ARMBasePayload(ViewMode mode, Guid id)
        {
            Mode = mode;
            Id = id;
        }

        /// <summary>
        /// Отримує або задає режим.
        /// </summary>
        public ViewMode Mode { get; protected set; }

        /// <summary>
        /// Отримує або задає метадату.
        /// </summary>
        public eARMMetadata Metadata { get; protected set; }

        /// <summary>
        /// Отримує або задає ідентифікатор.
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Задає метадату.
        /// </summary>
        /// <param name="metadata">Метадата.</param>
        protected void SetMetadata(eARMMetadata metadata)
        {
            Metadata = metadata;
        }
    }
}