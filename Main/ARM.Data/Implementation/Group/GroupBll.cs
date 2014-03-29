///////////////////////////////////////////////////////////
//  GroupBll.cs
//  Implementation of the Class GroupBll
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:40 PM
///////////////////////////////////////////////////////////

using ARM.Data.Interfaces.Group;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Group
{
    public class GroupBll : BaseBll<Models.Group>, IGroupBll
    {
        public GroupBll(IDal<Models.Group> dal)
            : base(dal)
        {
        }
    }//end GroupBll
}//end namespace Group