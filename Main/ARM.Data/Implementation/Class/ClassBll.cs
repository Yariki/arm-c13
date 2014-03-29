///////////////////////////////////////////////////////////
//  ClassBll.cs
//  Implementation of the Class ClassBll
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:38 PM
///////////////////////////////////////////////////////////

using ARM.Data.Interfaces.Class;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Class
{
    public class ClassBll : BaseBll<Models.Class>, IClassBll
    {
        public ClassBll(IDal<Models.Class> dal)
            : base(dal)
        {
        }
    }//end ClassBll
}//end namespace Class