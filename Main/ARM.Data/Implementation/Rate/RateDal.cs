﻿using ARM.Data.Interfaces.Rate;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Rate
{
    /// <summary>
    /// Реалізація доступу до даних для рейтингу
    /// </summary>
    public class RateDal : BaseDal<Models.Rate>, IRateDal
    {
        /// <summary>
        /// Створити екземпляр <see cref="RateDal"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public RateDal(IContext<Models.Rate> context)
            : base(context)
        {
        }
    }
}