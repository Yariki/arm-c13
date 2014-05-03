using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ARM.Core.Attributes;
using ARM.Core.Enums;

namespace ARM.Data.Models
{
    [ARMMetadata(Metadata =  eARMMetadata.Employer)]
    public class Employer : BaseNamedModel
    {
        public Employer()
        {
            Students = new List<Student>();
        }
        [ARMRequired]
        [ARMGrid(Order = 2)]
        [Display(ResourceType = typeof(Resource.AppResource.Resources),Name = "Model_Employer_Contact")]
        public string Contact { get; set; }
        [ARMRequired]
        [ARMGrid(Order = 3)]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_Employer_Phone")]
        public string Phone { get; set; }

        [ARMRequired]
        public string Email { get; set; }
        public string Url { get; set; }

        public virtual IList<Student> Students { get; set; } 
    }
}