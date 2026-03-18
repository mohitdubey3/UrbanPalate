using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UrbanPalate.Models;
using UrbanPalate.ViewModels;

namespace UrbanPalate.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;
        private readonly ILogger<AccountController> logger;

        public AccountController(UserManager<Users> userManager, SignInManager<Users> signInManager, ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Users usr = new Users()
                {
                    Name = model.Name,
                    Email = model.Email,
                    UserName = model.Email
                };
                var res = await userManager.CreateAsync(usr, model.Password);
                if (res.Succeeded)
                {
                    logger.LogInformation($"User {model.Email} registered successfully.");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var err in res.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var res = await signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);
                    if (res.Succeeded)
                    {
                        logger.LogInformation($"User {model.Email} logged in successfully.");
                        return RedirectToAction("Index", "Home");
                    }
                    else if (res.IsLockedOut)
                    {
                        ModelState.AddModelError("", "Account is locked out. Please try again later.");
                        logger.LogWarning($"Login attempt for locked account: {model.Email}");
                    }
                    else if (res.RequiresTwoFactor)
                    {
                        return RedirectToAction("LoginWith2fa");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid password.");
                        logger.LogWarning($"Invalid password attempt for user: {model.Email}");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email address.");
                    logger.LogWarning($"Login attempt with non-existent email: {model.Email}");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            if (signInManager.IsSignedIn(User))
            {
                await signInManager.SignOutAsync();
                logger.LogInformation($"User {User.Identity?.Name} logged out.");
                return RedirectToAction("Login", "Account");
            }
            return NotFound();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
