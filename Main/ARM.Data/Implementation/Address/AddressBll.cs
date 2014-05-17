﻿///////////////////////////////////////////////////////////
//  AddressBll.cs
//  Implementation of the Class AddressBll
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:37 PM
///////////////////////////////////////////////////////////

using ARM.Data.Interfaces.Address;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Address
{
    /// <summary>
    /// Реалізація бізнес логіки для адрес
    /// </summary>
    public class AddressBll : BaseBll<Models.Address>, IAddressBll
    {
        public AddressBll(IDal<Models.Address> dal)
            : base(dal)
        {
        }
    } //end AddressBll
} //end namespace Address