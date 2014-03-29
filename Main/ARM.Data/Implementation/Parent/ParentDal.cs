///////////////////////////////////////////////////////////
//  ParentDal.cs
//  Implementation of the Class ParentDal
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:44 PM
///////////////////////////////////////////////////////////

using ARM.Data.Interfaces.Parent;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Parent
{
    public class ParentDal : BaseDal<Models.Parent>, IParentDal
    {
        public ParentDal(IContext<Models.Parent> context)
            : base(context)
        {
        }
    }//end ParentDal
}//end namespace Parent