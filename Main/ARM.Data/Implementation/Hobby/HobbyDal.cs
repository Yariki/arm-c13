﻿///////////////////////////////////////////////////////////
//  HobbyDal.cs
//  Implementation of the Class HobbyDal
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:40 PM
///////////////////////////////////////////////////////////

using ARM.Data.Interfaces.Hobby;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Hobby
{
    /// <summary>
    /// Реалізація доступу до даних для хобі
    /// </summary>
    public class HobbyDal : BaseDal<Models.Hobby>, IHobbyDal
    {
        public HobbyDal(IContext<Models.Hobby> context)
            : base(context)
        {
        }
    } //end HobbyDal
} //end namespace Hobby