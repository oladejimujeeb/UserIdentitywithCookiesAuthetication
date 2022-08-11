using ApplicationIdentity.Identity;
using System.Collections.Generic;

namespace ApplicationIdentity.Interfaces.Identity
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User UpdateUser(User user);
        bool DeleteUser(User user);
        User GetUser(int id);
        User GetUser(string username);
        IList<User> GetUsers();
        IList<string> GetUserRoles(User user);
    }
}
