///////////////////////////////////////////////////////////
//  StaffDal.cs
//  Implementation of the Class StaffDal
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:45 PM
///////////////////////////////////////////////////////////

using ARM.Data.Interfaces.Staff;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Staff
{
    public class StaffDal : BaseDal<Models.Staff>, IStaffDal
    {
        public StaffDal(IContext<Models.Staff> context)
            : base(context)
        {
        }
    } //end StaffDal
} //end namespace Staff