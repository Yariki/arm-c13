using ARM.Data.Interfaces.Invoice;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Invoice
{
    /// <summary>
    /// Контекст бази даних для рахунків
    /// </summary>
    public class InvoiceContext : BaseContext<Models.Invoice>, IInvoiceContext
    {
    }
}