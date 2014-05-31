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
        /// <summary>
        /// Ініціалізіція нового екземпляра  <see cref="Login"/>.
        /// </summary>
        public Login()
        {
            
        }
        /// <summary>
        /// Отримує або задає назву.
        /// </summary>
        [ARMRequired]
        public string Name { get; set; }

        /// <summary>
        /// Отримує або задає пароль.
        /// </summary>
        [ARMRequired]
        public string Password { get; set; }
    }
}