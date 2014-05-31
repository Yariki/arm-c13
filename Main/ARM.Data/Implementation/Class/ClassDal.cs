﻿///////////////////////////////////////////////////////////
//  ClassDal.cs
//  Implementation of the Class ClassDal
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:38 PM
///////////////////////////////////////////////////////////

using ARM.Data.Interfaces.Class;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Class
{
    /// <summary>
    /// Реалізація доступу до даних для класів
    /// </summary>
    public class ClassDal : BaseDal<Models.Class>, IClassDal
    {
        /// <summary>
        /// Створити екземпляр <see cref="ClassDal"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ClassDal(IContext<Models.Class> context)
            : base(context)
        {
        }
    } //end ClassDal
} //end namespace Class