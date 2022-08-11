using ApplicationIdentity.DTOs;
using ApplicationIdentity.Identity;
using ApplicationIdentity.Interfaces.Identity;
using ApplicationIdentity.Interfaces.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ApplicationIdentity.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        //private readonly UserManager<User> _userManager;
        private readonly IIdentityService _identityService;
       

        public AuthController(IConfiguration configuration, IIdentityService identityService)
        {
            _configuration = configuration;
            //_userManager = userManager;
            _identityService = identityService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            var user = _identityService.FindByName(userName);
            if (user != null)
            {
                var isValidPassword = _identityService.CheckPassword(user, password);
                if (isValidPassword)
                {
                    var roles = _identityService.GetRoles(user);
                    _identityService.SetClaims(user, roles);
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Message = "Invalid Credential";
                return View();
            }
            ViewBag.Message = "Invalid Credential";
            return View();
        }


        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
