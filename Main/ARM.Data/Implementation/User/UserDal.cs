using System.Linq;
using ARM.Data.Interfaces.User;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.User
{
    /// <summary>
    /// Реалізація доступу до даних для користувачів
    /// </summary>
    public class UserDal : BaseDal<Models.User>, IUserDal
    {
        /// <summary>
        /// Створити екземпляр <see cref="UserDal"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UserDal(IContext<Models.User> context)
            : base(context)
        {
        }

        /// <summary>
        /// Повертає валідного користувача.
        /// </summary>
        /// <param name="username">Користувач.</param>
        /// <param name="password">Пароль.</param>
        /// <returns></returns>
        public Models.User GetValidUser(string username, string password)
        {
            var user = Context.GetItems()
                .FirstOrDefault(u => u.Name == username && u.Password == password && u.IsActive);
            return user;
        }
    }
}