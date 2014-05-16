using ARM.Data.Interfaces.Payment;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Payment
{
    public class PaymentContext
       : BaseContext<Models.Payment>, IPaymentContext
    {
    }
}