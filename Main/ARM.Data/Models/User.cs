using System.ComponentModel.DataAnnotations;
using ARM.Core.Attributes;
using ARM.Core.Enums;

namespace ARM.Data.Models
{
    [ARMMetadata(Metadata = eARMMetadata.User)]
    public class User : BaseNamedModel
    {
        [ARMRequired]
        public string Email { get; set; }

        [ARMRequired]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public eARMSystemLanguage Language { get; set; }

    }
}