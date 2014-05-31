using ARM.Data.Interfaces.Specialty;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Specialty
{
    /// <summary>
    /// Контекст бази даних для спеціальностей
    /// </summary>
    public class SpecialtyContext : BaseContext<Models.Specialty>, ISpecialtyContext
    {
        /// <summary>
        /// Створити екземпляр <see cref="SpecialtyContext"/> class.
        /// </summary>
        public SpecialtyContext()
        {
            
        }
    }
}