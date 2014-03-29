///////////////////////////////////////////////////////////
//  InvoiceBll.cs
//  Implementation of the Class InvoiceBll
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:42 PM
///////////////////////////////////////////////////////////

using ARM.Data.Interfaces.Invoice;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Invoice
{
    public class InvoiceBll : BaseBll<Models.Invoice>, IInvoiceBll
    {
        public InvoiceBll(IDal<Models.Invoice> dal)
            : base(dal)
        {
        }
    }//end InvoiceBll
}//end namespace Invoice