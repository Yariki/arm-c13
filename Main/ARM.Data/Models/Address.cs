///////////////////////////////////////////////////////////
//  Address.cs
//  Implementation of the Class Address
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:37 PM
///////////////////////////////////////////////////////////

using System.Collections.Generic;

namespace ARM.Data.Models
{
    public class Address : BaseModel
    {
        public Address()
        {
            Persons = new HashSet<Person>();
        }

        public long CountryId
        {
            get;
            set;
        }

        public string Region
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public string Street
        {
            get;
            set;
        }

        public string House
        {
            get;
            set;
        }

        public string Apartment
        {
            get;
            set;
        }

        public virtual Country Country
        {
            get;
            set;
        }

        public ICollection<Person> Persons
        {
            get;
            set;
        }
    }//end Address
}//end namespace Models