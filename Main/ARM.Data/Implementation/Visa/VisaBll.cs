using ARM.Data.Interfaces.Visa;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Visa
{

    /// <summary>
    /// Простір імен для реалізації функциональності по роботі з - візами
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    internal class NamespaceDoc
    {
    }
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