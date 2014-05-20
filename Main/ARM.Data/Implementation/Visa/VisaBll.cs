using ARM.Data.Interfaces.Visa;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Visa
{
    /// <summary>
    /// Реалізація бізнес логіки для віз
    /// </summary>
    public class VisaBll : BaseBll<Models.Visa>, IVisaBll
    {
        public VisaBll(IDal<Models.Visa> dal)
            : base(dal)
        {
        }
    }
}