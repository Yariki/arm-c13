using ARM.Core.Attributes;
using ARM.Core.Enums;

namespace ARM.Data.Models
{
    /// <summary>
    /// Модель логіну
    /// </summary>
    [ARMMetadata(Metadata = eARMMetadata.Login)]
    public class Login : BaseModel
    {
        [ARMRequired]
        public string Name { get; set; }

        [ARMRequired]
        public string Password { get; set; }
    }
}