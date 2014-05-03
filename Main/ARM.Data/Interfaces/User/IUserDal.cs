using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Interfaces.User
{
    public interface IUserDal : IDal<Models.User>
    {
        Models.User GetValidUser(string username, string password);
    }
}