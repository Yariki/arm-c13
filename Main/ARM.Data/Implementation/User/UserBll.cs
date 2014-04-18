using ARM.Data.Interfaces.User;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.User
{
    public class UserBll : BaseBll<Models.User>,IUserBll
    {
        public UserBll(IDal<Models.User> dal) : base(dal)
        {
        }
    }
}