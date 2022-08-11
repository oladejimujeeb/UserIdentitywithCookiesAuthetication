using ApplicationIdentity.Context;
using ApplicationIdentity.Identity;
using ApplicationIdentity.Interfaces.Identity;
using ApplicationIdentity.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationIdentity.Implementations.Identity
{
    public class UserStore : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserStore(ApplicationContext context)
        {
            _context = context;
        }
        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public bool DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public User GetUser(int id)
        {
            var user =_context.Users.Include(x => x.UserRoles).ThenInclude(r => r.Role).Where(x => x.Id == id).SingleOrDefault();
            return user;
        }

        public User GetUser(string username)
        {
            var user = _context.Users.Include(x => x.UserRoles).ThenInclude(r => r.Role).Where(x => x.UserName == username).SingleOrDefault();
            return user;
        }

        public IList<User> GetUsers()
        {
            var users = _context.Users.Include(x => x.UserRoles).ThenInclude(r => r.Role).ToList();
            return users;
        }

        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public IList<string> GetUserRoles(User user)
        {
            var userRoles = _context.UserRoles.Include(u => u.Role)
                .Where(u => u.User == user)
                .Select(r => r.Role.Name)
                .ToList();
            return userRoles;
        }
    }
}
