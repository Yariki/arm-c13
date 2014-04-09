///////////////////////////////////////////////////////////
//  SettingParameters.cs
//  Implementation of the Class SettingParameters
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:45 PM
///////////////////////////////////////////////////////////

using System;
using ARM.Core.Attributes;
using ARM.Core.Enums;

namespace ARM.Data.Models
{
  [ARMMetadata(Metadata = eARMMetadata.Settings)]

    public class SettingParameters : BaseModel
    {
        public SettingParameters()
        {
        }

        ~SettingParameters()
        {
        }

        public Guid DefUniversity
        {
            get;
            set;
        }

        public Guid DefCoutry
        {
            get;
            set;
        }

        public int DefEducationLevel
        {
            get;
            set;
        }

        public int DefInvoiceStatus
        {
            get;
            set;
        }

        public decimal DefBaseStipend
        {
            get;
            set;
        }

        public decimal DefIncreaseStipend
        {
            get;
            set;
        }

        public double DefStipendMark
        {
            get;
            set;
        }

        public double DefStipenHighMark
        {
            get;
            set;
        }
    }//end SettingParameters
}//end namespace Models