using ARM.Data.Interfaces.Country;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Country
{
    public class CountryContext : BaseContext<Models.Country>,ICountryContext
    {
         
    }
}