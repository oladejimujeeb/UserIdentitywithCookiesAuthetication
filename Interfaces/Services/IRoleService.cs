using ApplicationIdentity.Identity;
using System.Collections.Generic;

namespace ApplicationIdentity.Interfaces.Services
{
    public interface IRoleService
    {
        Role AddRole(Role role);
        Role UpdateRole(Role role);
        bool DeleteRole(Role role);
        Role GetRole(int id);
        IList<Role> GetRoles();
    }
}
