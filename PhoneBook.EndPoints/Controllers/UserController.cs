using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.EndPoints.Models.AAA;

namespace PhoneBook.EndPoints.Controllers
{
    public class UserController : Controller
    {
        public readonly UserManager<AppUser> userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = userManager.Users.Take(50).ToList();
            return View(user);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new()
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                var result = userManager.CreateAsync(user, model.Password).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
            }
            return View(model);
        }

        public IActionResult Update(string id)
        {
            var user = userManager.FindByIdAsync(id).Result;
            if (user != null)
            {
                UpdateUserViewModel model = new()
                {
                    Email = user.Email,
                    UserName = user.UserName,
                };
                return View(model);
            }
            return NotFound();
        }
        [HttpPut]
        public IActionResult Update(string id, UpdateUserViewModel model)
        {
            var user = userManager.FindByIdAsync(id).Result;
            if (user != null)
            {
                user.Email = model.Email;
                user.UserName = model.UserName;

                var result = userManager.UpdateAsync(user).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
                return View(model);
            }
            return NotFound();
        }
        public IActionResult Delete(string id)
        {
            var user = userManager.FindByIdAsync(id).Result;
            if (user != null)
            {
                var result = userManager.DeleteAsync(user).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
            }
            return View();
        }
    }
}
