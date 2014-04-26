///////////////////////////////////////////////////////////
//  SettingParameters.cs
//  Implementation of the Class SettingParameters
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:45 PM
///////////////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;
using ARM.Core.Attributes;
using ARM.Core.Enums;

namespace ARM.Data.Models
{
  [ARMMetadata(Metadata = eARMMetadata.Settings)]

    public class SettingParameters : BaseModel
    {
        [ARMRequired]
        public Guid DefUniversity
        {
            get;
            set;
        }
        
        [ARMRequired]
        public Guid DefCountry
        {
            get;
            set;
        }

        public EducationLevel DefEducationLevel
        {
            get;
            set;
        }
        
        public InvoiceStatus DefInvoiceStatus
        {
            get;
            set;
        }
        
        [ARMMin(Min = 0)]
        public decimal DefBaseStipend
        {
            get;
            set;
        }

        [ARMMin(Min = 0)]
        public decimal DefIncreaseStipend
        {
            get;
            set;
        }
        [ARMRange(Min = 0,Max = 6)]
        public double DefStipendMark
        {
            get;
            set;
        }
        [ARMMin(Min = 0)]
        public double DefStipenHighMark
        {
            get;
            set;
        }

    }//end SettingParameters
}//end namespace Models