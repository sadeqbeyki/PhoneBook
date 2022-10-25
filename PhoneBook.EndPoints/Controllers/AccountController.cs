using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.EndPoints.Models.AAA;

namespace PhoneBook.EndPoints.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<AppUser> userManager;
        public SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public ViewResult Login(string returnUrl)
        {
            return View(new PBLoginModel
            {
                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(PBLoginModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByNameAsync(model.Name);
                if (user == null)
                {
                    user = await userManager.FindByEmailAsync(model.Name);
                }
                if (user != null)
                {
                    //ممکن است از قبل ساین این باشد - پس ساین اوت میکنیم
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
                    {
                        return Redirect(model?.ReturnUrl ?? "/");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid Name Or Password");
            return View(model);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
