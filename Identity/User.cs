using ApplicationIdentity.Contracts;
using ApplicationIdentity.Entities;
using System.Collections.Generic;

namespace ApplicationIdentity.Identity
{
    public class User : AuditableEntity
    {
        public string UserName { get; set;}
        public string Password { get; set;}
        public Staff Staff { get; set;}
        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}
