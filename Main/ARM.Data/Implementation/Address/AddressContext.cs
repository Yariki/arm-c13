using ARM.Data.Interfaces.Address;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Address
{
    /// <summary>
    /// Контекст бази даних для адрес
    /// </summary>
    public class AddressContext : BaseContext<Models.Address>, IAddressContext
    {
    }
}