using ARM.Data.Interfaces.User;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.User
{
    public class UserDal : BaseDal<Models.User>,IUserDal
    {
        public UserDal(IContext<Models.User> context) 
            : base(context)
        {
        }
    }
}