///////////////////////////////////////////////////////////
//  BaseNamedModel.cs
//  Implementation of the Class BaseNamedModel
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:38 PM
///////////////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;
using ARM.Core.Attributes;

namespace ARM.Data.Models
{
    public abstract class BaseNamedModel : BaseModel
    {
        [ARMGrid(Order = 1)]
        [Display(ResourceType = typeof(ARM.Resource.AppResource.Resources), Name = "Model_Name")]
        [Required]
        public string Name
        {
            get;
            set;
        }
    }//end BaseNamedModel
}//end namespace Models