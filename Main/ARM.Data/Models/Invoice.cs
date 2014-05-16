///////////////////////////////////////////////////////////
//  Invoice.cs
//  Implementation of the Class Invoice
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:42 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ARM.Core.Attributes;
using ARM.Core.Enums;

namespace ARM.Data.Models
{
    [ARMMetadata(Metadata = eARMMetadata.Invoice)]
    public class Invoice : BaseNamedModel
    {
        [ARMRequired]
        [ARMGrid(Order = 2)]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_Invoice_Number")]
        public string Number { get; set; }

        [ARMRequired]
        public Guid ContractId
        {
            get;
            set;
        }

        [ARMRequired]
        public Guid? SessionId
        {
            get;
            set;
        }

        [ARMMin(Min = 0)]
        [ARMGrid(Order = 3)]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_Invoice_Price")]
        public decimal Price
        {
            get;
            set;
        }

        [ARMRequired]
        [ARMGrid(Order = 4)]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_Invoice_DateDue")]
        public DateTime DateDue
        {
            get;
            set;
        }

        [ARMRequired]
        [ARMGrid(Order = 5)]
        [Display(ResourceType = typeof(Resource.AppResource.Resources), Name = "Model_Invoice_Status")]
        public InvoiceStatus Status
        {
            get;
            set;
        }

        public virtual Contract Contract
        {
            get;
            set;
        }

        public virtual Session Session
        {
            get;
            set;
        }

        public virtual IList<Payment> Payments { get; set; }
    }//end Invoice
}//end namespace Models