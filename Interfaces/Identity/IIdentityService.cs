using ApplicationIdentity.Identity;
using System.Collections.Generic;

namespace ApplicationIdentity.Interfaces.Identity
{
    public interface IIdentityService
    {
        User FindByName(string userName);
        bool CheckPassword(User user, string password);
        IList<string> GetRoles(User user);
        void SetClaims(User user, IEnumerable<string> roles);
        string GetUserIdentity();
    }
}
