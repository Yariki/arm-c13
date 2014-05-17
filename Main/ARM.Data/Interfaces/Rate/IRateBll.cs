using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Interfaces.Rate
{
    /// <summary>
    /// Інтерфейс бізнес логіки  рейтингу
    /// </summary>
    public interface IRateBll : IBll<Models.Rate>
    {
        Models.Rate GetApproprialRate(decimal rate);
    }
}