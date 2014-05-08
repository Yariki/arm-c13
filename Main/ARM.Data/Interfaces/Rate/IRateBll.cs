using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Interfaces.Rate
{
    public interface IRateBll : IBll<Models.Rate>
    {
        Models.Rate GetApproprialRate(decimal rate);
    }
}