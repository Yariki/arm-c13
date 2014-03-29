///////////////////////////////////////////////////////////
//  University.cs
//  Implementation of the Class University
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:46 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace ARM.Data.Models
{
    public class University : BaseNamedModel
    {
    
    
        public Guid? StaffId
        {
            get;
            set;
        }

        public virtual Staff Rector
        {
            get;
            set;
        }

        public string Url { get; set; }
        public string Email { get; set; }

        public virtual IList<Faculty> Faculties { get; set; }

    }//end University
}//end namespace Models