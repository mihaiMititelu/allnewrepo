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
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }

        private SignInManager<User> SignInManager { get; }
        private UserManager<User> UserManager { get; set; }

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
                var userName = vm.Username.Replace(".", "");
                var signInResult = await SignInManager.PasswordSignInAsync(userName, vm.Password, true, false);

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
            if (ModelState.IsValid)
            {
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
              
                var result = await UserManager.CreateAsync(user, vm.Password);
               
                if (result.Succeeded)
                {
                    /*if (user.TipCont == 1)
                    {
                       await UserManager.AddToRoleAsync(user,  "Student");
                    }
                    if (user.TipCont == 2)
                    {
                        await UserManager.AddToRoleAsync(user, "Profesor");
                    }*/
                    await SignInManager.SignInAsync(user, true);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var identityError in result.Errors)
                    ModelState.AddModelError("", identityError.Description);
            }
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
                await SignInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}