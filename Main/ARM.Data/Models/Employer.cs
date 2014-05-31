using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ARM.Core.Attributes;
using ARM.Core.Enums;

namespace ARM.Data.Models
{
    /// <summary>
    /// Модель роботодавця
    /// </summary>
    [ARMMetadata(Metadata = eARMMetadata.Employer)]
    public class Employer : BaseNamedModel
    {
        /// <summary>
        /// Ініціалізіція нового екземпляра  <see cref="Employer"/>.
        /// </summary>
        public Employer()
        {
            Students = new List<Student>();
        }

        /// <summary>
        /// Отримує або задає контактну особу.
        /// </summary>
        [ARMRequired]
        [ARMGrid(Order = 2)]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_Employer_Contact")]
        public string Contact { get; set; }

        /// <summary>
        /// Отримує або задає телефон особи.
        /// </summary>
        [ARMRequired]
        [ARMGrid(Order = 3)]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_Employer_Phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Отримує або задає електронну пошту.
        /// </summary>
        [ARMRequired]
        public string Email { get; set; }

        /// <summary>
        /// Отримує або задає ссилку.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Отримує або задає список студентів.
        /// </summary>
        public virtual IList<Student> Students { get; set; }
    }
}