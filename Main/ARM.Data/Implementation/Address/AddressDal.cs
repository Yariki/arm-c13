﻿///////////////////////////////////////////////////////////
//  AddressDal.cs
//  Implementation of the Class AddressDal
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:37 PM
///////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ARM.Data.Interfaces.Address;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Address
{
    /// <summary>
    /// Реалізація доступу до даних для адрес
    /// </summary>
    public class AddressDal : BaseDal<Models.Address>, IAddressDal
    {
        /// <summary>
        /// Створити екземпляр <see cref="AddressDal"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public AddressDal(IContext<Models.Address> context)
            : base(context)
        {
        }

        /// <summary>
        /// Повернути модель даних з всіма задежними.
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Models.Address> GetAllWithRelated()
        {
            return Context.GetItems().Include(a => a.Country).AsEnumerable();
        }
    }//end AddressDal
}//end namespace Address