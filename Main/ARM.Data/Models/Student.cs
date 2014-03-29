///////////////////////////////////////////////////////////
//  Student.cs
//  Implementation of the Class Student
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:46 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace ARM.Data.Models
{
    public class Student : Person
    {
        public Student()
        {
        }

        ~Student()
        {
        }

        public virtual IList<Parent> Parents
        {
            get;
            set;
        }

        public long GroupId
        {
            get;
            set;
        }

        public virtual Group Group
        {
            get;
            set;
        }

        public virtual IList<Hobby> Hobbies
        {
            get;
            set;
        }

        public virtual IList<Achivement> Achivements
        {
            get;
            set;
        }

        public DateTime DateFirstEnter
        {
            get;
            set;
        }

        public DateTime DateLeft
        {
            get;
            set;
        }

        public ICollection<Language> Languages
        {
            get;
            set;
        }

        public long FacultyId
        {
            get;
            set;
        }

        public virtual Faculty Faculty
        {
            get;
            set;
        }

        public StudyMode StudyMode
        {
            get;
            set;
        }

        public string GradeBookNumber
        {
            get;
            set;
        }

        public long ContractId
        {
            get;
            set;
        }

        public virtual Contract Contract
        {
            get;
            set;
        }

        public bool IsForeign
        {
            get;
            set;
        }

        public long SpecialityId
        {
            get;
            set;
        }

        public virtual Specialty Speciality
        {
            get;
            set;
        }

        public StudentStatus Status
        {
            get;
            set;
        }
    }//end Student
}//end namespace Models