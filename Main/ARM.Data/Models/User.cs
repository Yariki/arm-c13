using System.ComponentModel.DataAnnotations;
using ARM.Core.Attributes;
using ARM.Core.Enums;

namespace ARM.Data.Models
{
    /// <summary>
    /// Модель корстувача
    /// </summary>
    [ARMMetadata(Metadata = eARMMetadata.User)]
    public class User : BaseNamedModel
    {
        /// <summary>
        /// Ініціалізіція нового екземпляра  <see cref="User"/>.
        /// </summary>
        public User()
        {
            
        }
        /// <summary>
        /// Отримує або задає електронну скриньку.
        /// </summary>
        [ARMGrid(Order = 2)]
        [ARMRequired]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_User_Email")]
        public string Email { get; set; }

        /// <summary>
        /// Отримує або задає пароль.
        /// </summary>
        [ARMRequired]
        public string Password { get; set; }

        /// <summary>
        /// Активний.
        /// </summary>
        [ARMGrid(Order = 3)]
        [ARMRequired]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_User_IsActive")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Отримує або задає мова інтерфейсу.
        /// </summary>
        [ARMGrid(Order = 4)]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_User_Language")]
        public eARMSystemLanguage Language { get; set; }
    }
}