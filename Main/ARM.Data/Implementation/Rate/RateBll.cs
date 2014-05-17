using System.Linq;
using ARM.Data.Interfaces.Rate;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Rate
{
    /// <summary>
    /// Реалізація бізнес логіки для рейтингу
    /// </summary>
    public class RateBll : BaseBll<Models.Rate>, IRateBll
    {
        public RateBll(IDal<Models.Rate> dal)
            : base(dal)
        {
        }

        public Models.Rate GetApproprialRate(decimal rate)
        {
            var Rate = Dal.GetAll().FirstOrDefault(r => r.RateMin <= rate && rate <= r.RateMax);
            return Rate;
        }
    }
}