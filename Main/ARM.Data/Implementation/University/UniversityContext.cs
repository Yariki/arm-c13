using ARM.Data.Interfaces.University;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.University
{
    /// <summary>
    /// Контекст бази даних для уніветситету
    /// </summary>
    public class UniversityContext : BaseContext<Models.University>, IUniversityContext
    {
        /// <summary>
        /// Створити екземпляр <see cref="UniversityContext"/> class.
        /// </summary>
        public UniversityContext()
        {
            
        }
    }
}