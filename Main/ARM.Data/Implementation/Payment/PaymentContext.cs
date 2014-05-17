using ARM.Data.Interfaces.Payment;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Payment
{
    /// <summary>
    /// Контекст бази даних для платіжок
    /// </summary>
    public class PaymentContext
       : BaseContext<Models.Payment>, IPaymentContext
    {
    }
}