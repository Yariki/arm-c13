///////////////////////////////////////////////////////////
//  Group.cs
//  Implementation of the Class Group
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:40 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARM.Core.Attributes;
using ARM.Core.Enums;

namespace ARM.Data.Models
{
    [ARMMetadata(Metadata = eARMMetadata.Group)]
    public class Group : BaseNamedModel
    {
        [ARMRequired]
        public Guid FacultyId
        {
            get;
            set;
        }

        [ARMGrid(Order = 2)]
        [Display(ResourceType = typeof(ARM.Resource.AppResource.Resources), Name = "Model_Group_Faculty")]
        public virtual Faculty Faculty
        {
            get;
            set;
        }

        [ARMRequired]
        public Guid? StaffId
        {
            get;
            set;
        }

        [ARMGrid(Order = 3)]
        [ForeignKey("StaffId")]
        [Display(ResourceType = typeof(ARM.Resource.AppResource.Resources), Name = "Model_Group_Curator")]
        public virtual Staff Curator
        {
            get;
            set;
        }

        public virtual IList<Student> Students
        {
            get;
            set;
        }

        public override string Display
        {
            get { return Name; }
        }
    }//end Group
}//end namespace Models