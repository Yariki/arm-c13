using ARM.Data.Interfaces.Invoice;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Invoice
{
    public class InvoiceContext : BaseContext<Models.Invoice>, IInvoiceContext
    {
    }
}