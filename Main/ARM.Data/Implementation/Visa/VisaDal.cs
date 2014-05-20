using ARM.Data.Interfaces.Visa;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Visa
{
    /// <summary>
    /// Реалізація доступу до даних для віз
    /// </summary>
    public class VisaDal : BaseDal<Models.Visa>, IVisaDal
    {
        public VisaDal(IContext<Models.Visa> context)
            : base(context)
        {
        }
    }
}