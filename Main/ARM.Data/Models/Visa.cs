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
        [ARMRequired]
        public string Number { get; set; }

        [ARMRequired]
        public string PlaceOfIssue { get; set; }

        [ARMRequired]
        public VisaType VisaType { get; set; }

        [ARMRequired]
        public string PassportNumber { get; set; }

        [ARMRequired]
        public DateTime ValidFrom { get; set; }

        [ARMRequired]
        public DateTime ValidUntil { get; set; }

        public Guid StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}