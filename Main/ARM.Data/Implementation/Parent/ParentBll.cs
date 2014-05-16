///////////////////////////////////////////////////////////
//  ParentBll.cs
//  Implementation of the Class ParentBll
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:44 PM
///////////////////////////////////////////////////////////

using ARM.Data.Interfaces.Parent;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Parent
{
    public class ParentBll : BaseBll<Models.Parent>, IParentBll
    {
        public ParentBll(IDal<Models.Parent> dal)
            : base(dal)
        {
        }
    } //end ParentBll
} //end namespace Parent