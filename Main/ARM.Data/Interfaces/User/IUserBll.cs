using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Interfaces.User
{ 
    public interface IUserBll : IBll<Models.User>
    {
        Models.User GetValidUser(string username, string password);
    }
}