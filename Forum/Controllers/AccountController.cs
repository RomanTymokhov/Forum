using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Forum.Models.ViewModels;
using Forum.Domain.Services;
using Forum.Models.Account;

namespace Forum.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMailService mailService;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(IMailService mailService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.mailService = mailService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser { Email = model.Email, UserName = model.Email };
                
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {   //email token generation                 
                    string code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    string callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new { userId = user.Id, code },
                        protocol: HttpContext.Request.Scheme);

                    await mailService.SendEmailAsync(model.Email, "Confirm your account",
                        $"Confirm the registration by clicking : <a href='{callbackUrl}'>on this link</a>");

                    var newUser = await userManager.FindByEmailAsync(model.Email);
                    await Authenticate(newUser);

                    return Content("<h2>To complete the registration, check the email and click on the link indicated in the letter.</h2>");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("Error");
            }
            var result = await userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return RedirectToAction("Updates", "Forum");
            else
                return View("Error");
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Email);
                if (user != null)
                {
                    // check if email is confirmed
                    if (!await userManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError(string.Empty, "You have not confirmed your email");
                        return View(model);
                    }

                    await Authenticate(user);
                }

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);

                if (result.Succeeded)
                {
                    //check if the URL belongs to the application
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Updates", "Forum");
                    }
                    //return RedirectToAction("Updates", "Forum");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username and / or password");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            // delete authentication cookies
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private async Task Authenticate(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Id)
            };
            var userIdentity = new ClaimsIdentity(claims, "login");
            var principal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync(principal);
        }
    }
}