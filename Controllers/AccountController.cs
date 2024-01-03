using CVProjekt1._0.Models;
using CVProjekt1._0.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CVProjekt1._0.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AccountController(UserManager<User> userMgr, SignInManager<User> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if(ModelState.IsValid)
            {
                User anvandare = new User();
                anvandare.UserName = registerViewModel.Username;
                var result = await userManager.CreateAsync(anvandare, registerViewModel.Password);
                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(anvandare, isPersistent: true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(registerViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
			if(ModelState.IsValid)
            {
				var result = await signInManager.PasswordSignInAsync(loginViewModel.UserName,
                                                                    loginViewModel.Password,
                                                                    isPersistent: loginViewModel.RememberMe,
                                                                    lockoutOnFailure: false);
				if(result.Succeeded)
                {
					return RedirectToAction("Index", "Home");
				}
				else
                {
					ModelState.AddModelError("", "Login failed");
				}
			}
			return View(loginViewModel);
		}

        public async Task<IActionResult> Logout()
        {
			await signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
    }
}
