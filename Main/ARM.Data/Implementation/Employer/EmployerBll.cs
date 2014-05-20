using ARM.Data.Interfaces.Employer;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Employer
{
    /// <summary>
    /// Реалізація бізнес логіки для роботодавців
    /// </summary>
    public class EmployerBll : BaseBll<Models.Employer>, IEmployerBll
    {
        public EmployerBll(IDal<Models.Employer> dal)
            : base(dal)
        {
        }
    }
}