using System;
using ARM.Core.Attributes;
using ARM.Core.Enums;

namespace ARM.Data.Models
{
    /// <summary>
    /// Модель візи
    /// </summary>
    [ARMMetadata(Metadata = eARMMetadata.Visa)]
    public class Visa : BaseNamedModel
    {
        /// <summary>
        /// Ініціалізіція нового екземпляра  <see cref="Visa"/>.
        /// </summary>
        public Visa()
        {
            
        }
        /// <summary>
        /// Отримує або задає номер.
        /// </summary>
        [ARMRequired]
        public string Number { get; set; }

        /// <summary>
        /// Отримує або задає мусце видачі.
        /// </summary>
        [ARMRequired]
        public string PlaceOfIssue { get; set; }

        /// <summary>
        /// Тип візи.
        /// </summary>
        [ARMRequired]
        public VisaType VisaType { get; set; }

        /// <summary>
        /// Отримує або задає номер паспорту.
        /// </summary>
        [ARMRequired]
        public string PassportNumber { get; set; }

        /// <summary>
        /// Отримує або задає дату з якої дійсна.
        /// </summary>
        [ARMRequired]
        public DateTime ValidFrom { get; set; }

        /// <summary>
        /// Отримує або задає дату до якрї дійсна.
        /// </summary>
        [ARMRequired]
        public DateTime ValidUntil { get; set; }

        /// <summary>
        /// Отримує або задає ідентифікатор студента.
        /// </summary>
        public Guid StudentId { get; set; }

        /// <summary>
        /// Отримує або задає студента.
        /// </summary>
        public virtual Student Student { get; set; }
    }
}