using ARM.Data.Interfaces.Rate;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Rate
{
    /// <summary>
    /// Контекст бази даних для рейтингу
    /// </summary>
    public class RateContext : BaseContext<Models.Rate>, IRateContext
    {
        /// <summary>
        /// Створити екземпляр <see cref="RateContext"/> class.
        /// </summary>
        public RateContext()
        {
            
        }
    }
}