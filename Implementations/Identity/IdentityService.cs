using ApplicationIdentity.Identity;
using ApplicationIdentity.Interfaces.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApplicationIdentity.Implementations.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _context;
        private readonly IConfiguration _configuration;

        public IdentityService(IUserRepository userRepository, IHttpContextAccessor context, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _context = context;
            _configuration = configuration;
        }

        public bool CheckPassword(User user, string password)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if(user.Password == password)
            {
                return true;
            }
            return false;
        }

        public User FindByName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }
            var user = _userRepository.GetUser(userName);
            return user;
        }

        public IList<string> GetRoles(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var roles = _userRepository.GetUserRoles(user);
            return roles;
        }

        public string GetUserIdentity()
        {
            var user = _context.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return user;
        }

        public void SetClaims(User user, IEnumerable<string> roles)
        {
            IList<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.UserName)
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authenticationProperties = new AuthenticationProperties();
            var principal = new ClaimsPrincipal(claimsIdentity);
            _context.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
        }
    }
}
