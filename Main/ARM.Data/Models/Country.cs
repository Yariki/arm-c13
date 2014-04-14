///////////////////////////////////////////////////////////
//  Country.cs
//  Implementation of the Class Country
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:39 PM
///////////////////////////////////////////////////////////

using System.Collections.Generic;
using ARM.Core.Attributes;
using ARM.Core.Enums;

namespace ARM.Data.Models
{
    [ARMMetadata(Metadata = eARMMetadata.Country)]
    public class Country : BaseNamedModel
    {
        public virtual IList<Address> Addresses { get; set; }
    }//end Country
}//end namespace Models