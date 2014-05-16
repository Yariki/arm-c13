///////////////////////////////////////////////////////////
//  Mark.cs
//  Implementation of the Class Mark
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:43 PM
///////////////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;
using ARM.Core.Attributes;
using ARM.Core.Enums;

namespace ARM.Data.Models
{
    [ARMMetadata(Metadata = eARMMetadata.Mark)]
    public class Mark : BaseNamedModel
    {
        [ARMRequired]
        public Guid? StudentId
        {
            get;
            set;
        }

        [ARMRequired]
        public Guid? ClassId
        {
            get;
            set;
        }

        [ARMGrid(Order = 2)]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_Mark_Student")]
        public virtual Student Student
        {
            get;
            set;
        }

        [ARMGrid(Order = 3)]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_Mark_Class")]
        public virtual Class Class
        {
            get;
            set;
        }

        [ARMRequired]
        [ARMGrid(Order = 7)]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_Mark_Date")]
        public DateTime? Date
        {
            get;
            set;
        }

        [ARMGrid(Order = 4)]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_Mark_Type")]
        public MarkType Type
        {
            get;
            set;
        }

        [ARMGrid(Order = 5)]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_Mark_MarkRate")]
        public decimal MarkRate { get; set; }

        [ARMGrid(Order = 6)]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_Mark_IsCertification")]
        public bool IsCertification { get; set; }
    }//end Mark
}//end namespace Models