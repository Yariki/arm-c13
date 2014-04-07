///////////////////////////////////////////////////////////
//  Person.cs
//  Implementation of the Class Person
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:44 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARM.Data.Models
{
    public abstract class Person : BaseModel
    {
        
        public string FirstName
        {
            get;
            set;
        }

        public String MiddleName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string PhoneMobile
        {
            get;
            set;
        }

        public string PhoneHome
        {
            get;
            set;
        }

        public SexType Sex
        {
            get;
            set;
        }
    }//end Person
}//end namespace Models