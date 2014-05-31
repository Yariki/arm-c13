using ARM.Data.Interfaces.Employer;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Employer
{
    /// <summary>
    /// Контекст бази даних для роботодавців
    /// </summary>
    public class EmployerContext : BaseContext<Models.Employer>, IEmployerContext
    {
        /// <summary>
        /// Створити екземпляр <see cref="EmployerContext"/> class.
        /// </summary>
        public EmployerContext()
        {
            
        }
    }
}