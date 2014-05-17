using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Interfaces.User
{
    /// <summary>
    /// Інтерфейс доступу до даних користувачів
    /// </summary>
    public interface IUserDal : IDal<Models.User>
    {
        Models.User GetValidUser(string username, string password);
    }
}