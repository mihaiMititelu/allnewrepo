using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DungeonMaster.Models;
using DungeonMaster.ViewModels;

namespace DungeonMaster.Controllers
{
    public class AuthController : Controller
    {
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel vm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var userName = vm.Username;
#pragma warning disable CS1701 // Assuming assembly reference matches identity
                var signInResult = await _signInManager.PasswordSignInAsync(userName, vm.Password, true, false);
#pragma warning restore CS1701 // Assuming assembly reference matches identity

                if (signInResult.Succeeded)
                    if (string.IsNullOrWhiteSpace(returnUrl))
                        return RedirectToAction("Index", "Home");
                    else
                        return Redirect(returnUrl);
#pragma warning disable CS1701 // Assuming assembly reference matches identity
                ModelState.AddModelError("", "Email or password wrong");
#pragma warning restore CS1701 // Assuming assembly reference matches identity
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid) return View();
            var user = new User
            {
                Email = vm.Email.Trim(),
                UserName = vm.Email.Substring(0, vm.Email.IndexOf('@')).Trim(),
                Password = vm.Password.Trim(),
            };
              
            var result = await _userManager.CreateAsync(user, vm.Password);
               
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, true);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Email already in use!");
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        public async Task<ActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
                await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}