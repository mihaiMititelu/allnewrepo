using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using UniFIIcation.Models;
using UniFIIcation.ViewModels;

namespace UniFIIcation.Controllers
{
    public class AuthController : Controller
    {
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;

            roleManager.CreateAsync(new IdentityRole("Profesor"));
            roleManager.CreateAsync(new IdentityRole("Student"));
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
                var signInResult = await _signInManager.PasswordSignInAsync(userName, vm.Password, true, false);

                if (signInResult.Succeeded)
                    if (string.IsNullOrWhiteSpace(returnUrl))
                        return RedirectToAction("Index", "Home");
                    else
                        return Redirect(returnUrl);
                ModelState.AddModelError("", "Email-ul sau parola greșite");
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
                Nume = vm.Nume.Trim(),
                Prenume = vm.Prenume.Trim(),
                Password = vm.Password.Trim(),
                An = vm.An,
                TipCont = vm.TipCont
            };
              
            var result = await _userManager.CreateAsync(user, vm.Password);
               
            if (result.Succeeded)
            {
                if (user.TipCont == 1)
                {
                    await _userManager.AddToRoleAsync(user, "Studenti");
                }
                if (user.TipCont == 2)
                {
                    await _userManager.AddToRoleAsync(user, "Profesor");
                }
                await _signInManager.SignInAsync(user, true);
                return RedirectToAction("Index", "Home");
            }

                ModelState.AddModelError("", "Email-ul exista deja");
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