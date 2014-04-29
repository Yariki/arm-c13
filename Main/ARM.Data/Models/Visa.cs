using System;
using ARM.Core.Attributes;
using ARM.Core.Enums;

namespace ARM.Data.Models
{
    [ARMMetadata(Metadata =  eARMMetadata.Visa)]
    public class Visa : BaseNamedModel
    {

        public string Number { get; set; }

        public string PlaceOfIssue { get; set; }

        public VisaType VisaType { get; set; }

        public string PassportNumber { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidUntil { get; set; }

        public Guid StudentId { get; set; }

        public virtual Student Student { get; set; }


    }
}