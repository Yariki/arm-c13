using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Interfaces.User
{
    /// <summary>
    /// Інтерфейс бізнес логіки користувачів
    /// </summary>
    public interface IUserBll : IBll<Models.User>
    {
        Models.User GetValidUser(string username, string password);
    }
}