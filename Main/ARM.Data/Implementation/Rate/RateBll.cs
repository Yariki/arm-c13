﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ARM.Data.Interfaces.Rate;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Rate
{


    /// <summary>
    /// Простір імен для реалізації функциональності по роботі з - рейтингами/балами
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    internal class NamespaceDoc
    {
    }
    /// <summary>
    /// Реалізація бізнес логіки для рейтингу
    /// </summary>
    public class RateBll : BaseBll<Models.Rate>, IRateBll
    {
        #region [needs]

        /// <summary>
        /// The low rate maximum value
        /// </summary>
        private const decimal LowRateMaxValue = 40;
        /// <summary>
        /// The low rate maximum value60
        /// </summary>
        private const decimal LowRateMaxValue60 = 60;

        private IEnumerable<Models.Rate> _lowRatesCollection =  null; 

        #endregion

        /// <summary>
        /// Створити екземпляр <see cref="RateBll"/> class.
        /// </summary>
        /// <param name="dal">The dal.</param>
        public RateBll(IDal<Models.Rate> dal)
            : base(dal)
        {
            _lowRatesCollection =
                new List<Models.Rate>(Dal.GetAsQueryable().Where(r => r.RateMax == LowRateMaxValue));
        }

        /// <summary>
        /// Визначає відповідний рейтинг.
        /// </summary>
        /// <param name="rate">Розрахований рейтинг.</param>
        /// <returns></returns>
        public Models.Rate GetApproprialRate(decimal rate)
        {
            var Rate = Dal.GetAll().FirstOrDefault(r => r.RateMin <= rate && rate <= r.RateMax);
            return Rate;
        }

        /// <summary>
        /// Повертає рейтинг з найменшими балами.
        /// F.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Models.Rate GetLowRate()
        {
            return Dal.GetAsQueryable().FirstOrDefault(r => r.RateMax == LowRateMaxValue);
        }

        /// <summary>
        /// Повертає рейтинг - Fx.
        /// </summary>
        /// <returns></returns>
        public Models.Rate GetLowRate60()
        {
            return Dal.GetAsQueryable().FirstOrDefault(r => r.RateMax == LowRateMaxValue60);
        }

    }
}