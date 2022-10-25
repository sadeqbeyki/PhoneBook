using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.EndPoints.Models.AAA;

namespace PhoneBook.EndPoints.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        public readonly RoleManager<PBIdentityRole> roleManager;

        public RoleController(RoleManager<PBIdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                PBIdentityRole role = new()
                {
                    Name = model.Name
                };
                var result = roleManager.CreateAsync(role).Result;
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
    }
}
