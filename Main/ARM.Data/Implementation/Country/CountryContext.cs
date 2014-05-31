using ARM.Data.Interfaces.Country;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Country
{
    /// <summary>
    /// Контекст бази даних для країн
    /// </summary>
    public class CountryContext : BaseContext<Models.Country>, ICountryContext
    {
        /// <summary>
        /// Створити екземпляр <see cref="CountryContext"/> class.
        /// </summary>
        public CountryContext()
        {
            
        }
    }
}