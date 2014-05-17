using ARM.Data.Interfaces.User;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.User
{
    /// <summary>
    /// Контекст бази даних для користувачів
    /// </summary>
    public class UserContext : BaseContext<Models.User>, IUserContext
    {
    }
}