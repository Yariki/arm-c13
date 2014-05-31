using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Interfaces.User
{
    /// <summary>
    /// Інтерфейс доступу до даних користувачів
    /// </summary>
    public interface IUserDal : IDal<Models.User>
    {
        /// <summary>
        /// Повернути валідного користувача.
        /// </summary>
        /// <param name="username">Імя.</param>
        /// <param name="password">Пароль.</param>
        /// <returns></returns>
        Models.User GetValidUser(string username, string password);
    }
}