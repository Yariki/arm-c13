///////////////////////////////////////////////////////////
//  AddressDal.cs
//  Implementation of the Class AddressDal
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:37 PM
///////////////////////////////////////////////////////////

using ARM.Data.Interfaces.Address;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Address
{
    public class AddressDal : BaseDal<Models.Address>, IAddressDal
    {
        public AddressDal(IContext<Models.Address> context)
            : base(context)
        {
        }
    }//end AddressDal
}//end namespace Address