using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Interfaces.User
{
    /// <summary>
    /// Простір імен інтерфейсів для моделей даних - користувач
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    internal class NamespaceDoc
    {
    }
    /// <summary>
    /// Інтерфейс бізнес логіки користувачів
    /// </summary>
    public interface IUserBll : IBll<Models.User>
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