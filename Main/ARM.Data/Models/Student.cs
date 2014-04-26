///////////////////////////////////////////////////////////
//  Student.cs
//  Implementation of the Class Student
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:46 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARM.Core.Attributes;
using ARM.Core.Enums;

namespace ARM.Data.Models
{
    [ARMMetadata(Metadata = eARMMetadata.Student)]

    public class Student : Person
    {

        public Student()
        {
            Achivements = new List<Achivement>();
            Languages = new HashSet<Language>();
        }

        [ARMRequired]
        public Guid AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        [ARMRequired]
        public Guid LivingAddressId { get; set; }

        [ForeignKey("LivingAddressId")]
        public virtual Address LivingAddress { get; set; }

        public virtual IList<Parent> Parents
        {
            get;
            set;
        }

        [ARMRequired]
        [Display(ResourceType = typeof(Resource.AppResource.Resources),Name="Model_Student_Group")]
        [ARMGrid(Order = 8)]
        public Guid? GroupId
        {
            get;
            set;
        }

        public virtual Group Group
        {
            get;
            set;
        }

        public virtual List<Hobby> Hobbies
        {
            get;
            set;
        }

        public virtual List<Achivement> Achivements
        {
            get;
            set;
        }

        [ARMRequired]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_Student_DateEnter")]
        [ARMGrid(Order = 9)]
        public DateTime DateFirstEnter
        {
            get;
            set;
        }

        public DateTime? DateLeft
        {
            get;
            set;
        }

        public virtual ICollection<Language> Languages
        {
            get;
            set;
        }

        [ARMRequired]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_Student_Faculty")]
        [ARMGrid(Order = 10)]
        public Guid? FacultyId
        {
            get;
            set;
        }

        public virtual Faculty Faculty
        {
            get;
            set;
        }

        [ARMRequired]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_Student_StudyMode")]
        [ARMGrid(Order = 11)]
        public StudyMode StudyMode
        {
            get;
            set;
        }

        [ARMRequired]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_Student_GradeBookNumber")]
        public string GradeBookNumber
        {
            get;
            set;
        }

        public virtual IList<Contract> Contracts { get; set; }

        [ARMRequired]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_Student_IsForeign")]
        [ARMGrid(Order = 12)]
        public bool IsForeign
        {
            get;
            set;
        }

        [ARMRequired]
        public Guid? SpecialityId
        {
            get;
            set;
        }

        public virtual Specialty Speciality
        {
            get;
            set;
        }

        [ARMRequired]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_Student_Status")]
        [ARMGrid(Order = 13)]
        public StudentStatus Status
        {
            get;
            set;
        }

        public virtual IList<Mark> Marks { get; set; }

    }//end Student
}//end namespace Models