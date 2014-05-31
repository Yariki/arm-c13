using ARM.Data.Interfaces.Employer;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Employer
{
    /// <summary>
    /// Реалізація доступу до даних для роботодавців
    /// </summary>
    public class EmployerDal : BaseDal<Models.Employer>, IEmployerDal
    {
        /// <summary>
        /// Створити екземпляр <see cref="EmployerDal"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public EmployerDal(IContext<Models.Employer> context)
            : base(context)
        {
        }
    }
}