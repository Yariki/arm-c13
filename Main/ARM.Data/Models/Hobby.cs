///////////////////////////////////////////////////////////
//  Hobby.cs
//  Implementation of the Class Hobby
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:40 PM
///////////////////////////////////////////////////////////

using System;
using ARM.Core.Attributes;
using ARM.Core.Enums;

namespace ARM.Data.Models
{
  [ARMMetadata(Metadata = eARMMetadata.Hobby)]
    public class Hobby : BaseNoteModel
    {
        public Hobby()
        {
        }

        ~Hobby()
        {
        }

        public Guid StudentId
        {
            get;
            set;
        }

        public virtual Student Student
        {
            get;
            set;
        }

    }//end Hobby
}//end namespace Models