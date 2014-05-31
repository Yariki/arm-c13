﻿///////////////////////////////////////////////////////////
//  SpecialtyDal.cs
//  Implementation of the Class SpecialtyDal
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:45 PM
///////////////////////////////////////////////////////////

using ARM.Data.Interfaces.Specialty;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Specialty
{
    /// <summary>
    /// Реалізація доступу до даних для спеціальностей
    /// </summary>
    public class SpecialtyDal : BaseDal<Models.Specialty>, ISpecialtyDal
    {
        /// <summary>
        /// Створити екземпляр <see cref="SpecialtyDal"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SpecialtyDal(IContext<Models.Specialty> context)
            : base(context)
        {
        }
    } //end SpecialtyDal
} //end namespace Specialty