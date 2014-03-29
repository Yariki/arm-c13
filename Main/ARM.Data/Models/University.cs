///////////////////////////////////////////////////////////
//  University.cs
//  Implementation of the Class University
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:46 PM
///////////////////////////////////////////////////////////

namespace ARM.Data.Models
{
    public class University : BaseNamedModel
    {
        public University()
        {
        }

        ~University()
        {
        }

        public long StaffId
        {
            get;
            set;
        }

        public virtual Staff Rector
        {
            get;
            set;
        }
    }//end University
}//end namespace Models