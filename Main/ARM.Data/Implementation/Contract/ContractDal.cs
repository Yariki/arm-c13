﻿///////////////////////////////////////////////////////////
//  ContractDal.cs
//  Implementation of the Class ContractDal
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:39 PM
///////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ARM.Data.Interfaces.Contract;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Contract
{
    /// <summary>
    /// Реалізація доступу до даних для контрактів
    /// </summary>
    public class ContractDal : BaseDal<Models.Contract>, IContractDal
    {
        /// <summary>
        /// Створити екземпляр <see cref="ContractDal"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ContractDal(IContext<Models.Contract> context)
            : base(context)
        {
        }

        #region IContractDal Members

        /// <summary>
        /// Повернути модель з всіма залежними.
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Models.Contract> GetAllWithRelated()
        {
            return Context.GetItems().Include(c => c.Customer).Include(c => c.Student).AsEnumerable();
        }

        #endregion IContractDal Members
    } //end ContractDal
} //end namespace Contract