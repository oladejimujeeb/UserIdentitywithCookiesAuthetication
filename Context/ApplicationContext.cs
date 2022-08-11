using ApplicationIdentity.Entities;
using ApplicationIdentity.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApplicationIdentity.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}
