using ApplicationIdentity.Identity;
using ApplicationIdentity.Interfaces.Identity;
using ApplicationIdentity.Interfaces.Services;
using System.Collections.Generic;

namespace ApplicationIdentity2.Implementations.Services
{
    public class RoleService : IRoleService
    {
   
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public Role AddRole(Role role)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteRole(Role role)
        {
            throw new System.NotImplementedException();
        }

        public Role GetRole(int id)
        {
            throw new System.NotImplementedException();
        }

        public IList<Role> GetRoles()
        {
           var roles = _roleRepository.GetRoles();
            return roles;
        }

        public Role UpdateRole(Role role)
        {
            throw new System.NotImplementedException();
        }
    }
}
