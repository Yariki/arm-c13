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
        [ARMGrid(Order = 2)]
        [ARMRequired]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_User_Email")]
        public string Email { get; set; }

        [ARMRequired]
        public string Password { get; set; }

        [ARMGrid(Order = 3)]
        [ARMRequired]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_User_IsActive")]
        public bool IsActive { get; set; }

        [ARMGrid(Order = 4)]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_User_Language")]
        public eARMSystemLanguage Language { get; set; }
    }
}