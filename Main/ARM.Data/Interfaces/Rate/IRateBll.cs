using System;
using System.Collections.Generic;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Interfaces.Rate
{
    /// <summary>
    /// Простір імен інтерфейсів для моделей даних - рейтинг/бали
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    internal class NamespaceDoc
    {
    }

    /// <summary>
    /// Інтерфейс бізнес логіки  рейтингу
    /// </summary>
    public interface IRateBll : IBll<Models.Rate>
    {
        /// <summary>
        /// Визначає відповідний рейтинг.
        /// </summary>
        /// <param name="rate">Розрахований рейтинг.</param>
        /// <returns></returns>
        Models.Rate GetApproprialRate(decimal rate);

        /// <summary>
        /// Повертає рейтинг з найменшими балами.
        /// F.
        /// </summary>
        /// <returns></returns>
        Models.Rate GetLowRate();

        /// <summary>
        /// Повертає рейтинг - Fx.
        /// </summary>
        /// <returns></returns>
        Models.Rate GetLowRate60();
    }
}