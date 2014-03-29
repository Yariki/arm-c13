///////////////////////////////////////////////////////////
//  Invoice.cs
//  Implementation of the Class Invoice
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:42 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARM.Data.Models
{
    public class Invoice : BaseNamedModel
    {
        public Invoice()
        {
        }

        ~Invoice()
        {
        }
        [Required]
        public Guid ContractId
        {
            get;
            set;
        }

        public Guid? SessionId
        {
            get;
            set;
        }
        [Required]
        public decimal Price
        {
            get;
            set;
        }

        public DateTime DateDue
        {
            get;
            set;
        }

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