///////////////////////////////////////////////////////////
//  CountryDal.cs
//  Implementation of the Class CountryDal
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:39 PM
///////////////////////////////////////////////////////////

using ARM.Data.Interfaces.Country;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Country
{
    public class CountryDal : BaseDal<Models.Country>, ICountryDal
    {
        public CountryDal(IContext<Models.Country> context)
            : base(context)
        {
        }
    }//end CountryDal
}//end namespace Country