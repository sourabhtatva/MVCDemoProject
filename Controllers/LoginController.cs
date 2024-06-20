using DemoProject.Models;
using DemoProject.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace DemoProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _authService;

        public LoginController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IAuthService authService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _authService.AuthenticateAsync(loginDto);
                    //var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);

                    if (result!=null)
                    {
                        return RedirectToAction("Index", "Users");
                    }
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
                return View(loginDto);

            }
            catch (Exception)
            {

                throw;

            }
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}