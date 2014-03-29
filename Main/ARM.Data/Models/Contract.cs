///////////////////////////////////////////////////////////
//  Contract.cs
//  Implementation of the Class Contract
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:39 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARM.Data.Models
{
    public class Contract : BaseNoteModel
    {
        [Required]
        public string Number { get; set; }

        public EducationLevel Level { get; set; }

        [Required]
        public Guid? ParentId { get; set; }

        public Guid UniversityId { get; set; }

        public Guid? StudentId { get; set; }

        public Guid? SpecialityId { get; set; }

        public decimal Price { get; set; }

        public virtual Parent Customer { get; set; }

        public virtual University University { get; set; }

        public virtual Student Student { get; set; }

        public virtual Specialty Speciality { get; set; }

        ~Contract()
        {
        }

        public virtual IList<Invoice> Invoices { get; set; }
    } //end Contract
} //end namespace Models