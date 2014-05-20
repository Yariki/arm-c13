﻿///////////////////////////////////////////////////////////
//  Faculty.cs
//  Implementation of the Class Faculty
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:39 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using ARM.Core.Attributes;
using ARM.Core.Enums;

namespace ARM.Data.Models
{
    /// <summary>
    /// Модель факультету
    /// </summary>
    [ARMMetadata(Metadata = eARMMetadata.Faculty)]
    public class Faculty : BaseNamedModel
    {
        [ARMRequired]
        public Guid? StaffId
        {
            get;
            set;
        }

        public string Url { get; set; }

        public virtual Staff Head
        {
            get;
            set;
        }

        [ARMRequired]
        public Guid UniversityId
        {
            get;
            set;
        }

        public virtual University University
        {
            get;
            set;
        }

        public virtual IList<Group> Groups { get; set; }

        public override string Display
        {
            get { return Name; }
        }
    }//end Faculty
}//end namespace Models