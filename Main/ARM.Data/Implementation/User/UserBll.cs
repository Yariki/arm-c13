using System.Security.Cryptography;
using System.Text;
using ARM.Data.Interfaces.User;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.User
{
    /// <summary>
    /// Реалізація бізнес логіки для користувача
    /// </summary>
    public class UserBll : BaseBll<Models.User>, IUserBll
    {
        public UserBll(IDal<Models.User> dal)
            : base(dal)
        {
        }

        public Models.User GetValidUser(string username, string password)
        {
            string md5hash = GetMd5Hash(MD5.Create(), password);
            return (Dal as IUserDal).GetValidUser(username, md5hash);
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}