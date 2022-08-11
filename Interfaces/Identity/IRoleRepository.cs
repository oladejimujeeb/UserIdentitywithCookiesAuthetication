using ApplicationIdentity.Identity;
using System.Collections.Generic;

namespace ApplicationIdentity.Interfaces.Identity
{
    public interface IRoleRepository
    {
        Role AddRole(Role role);
        Role UpdateRole(Role role);
        bool DeleteRole(Role role);
        Role GetRole(int id);
        IList<Role> GetRoles();
        IList<Role> GetSelectedRoles(IList<int> ids);
    }
}
