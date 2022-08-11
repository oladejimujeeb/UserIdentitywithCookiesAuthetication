using ApplicationIdentity.Context;
using ApplicationIdentity.Identity;
using ApplicationIdentity.Interfaces.Identity;
using ApplicationIdentity.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationIdentity.Implementations.Identity
{
    public class RoleStore : IRoleRepository
    {
        private readonly ApplicationContext _context;
        public RoleStore(ApplicationContext context)
        {
            _context = context;
        }
        public Role AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role;
        }

        public bool DeleteRole(Role role)
        {
            _context.Roles.Remove(role);
            _context.SaveChanges();
            return true;
        }

        public Role GetRole(int id)
        {
            var role = _context.Roles.Include(x => x.UserRoles).ThenInclude(u => u.User).Where(x => x.Id == id).SingleOrDefault();
            return role;
        }

        public IList<Role> GetRoles()
        {
            var roles = _context.Roles.Include(x => x.UserRoles).ThenInclude(u => u.User).ToList();
            return roles;
        }

        public IList<Role> GetSelectedRoles(IList<int> ids)
        {
            var roles = _context.Roles.Where(x => ids.Contains(x.Id)).ToList();
            return roles;
        }

        public Role UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
            return role;
        }
    }
}
