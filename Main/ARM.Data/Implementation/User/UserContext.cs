using ARM.Data.Interfaces.User;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.User
{
    public class UserContext : BaseContext<Models.User>, IUserContext
    {
    }
}