using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.EndPoints.Models.AAA;

namespace PhoneBook.EndPoints.Controllers;

//[Authorize]
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
    #region Create

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
    #endregion
    #region Update

    [HttpGet]
    public IActionResult Update(int id)
    {
        var role = roleManager.FindByIdAsync(id.ToString()).Result;
        if (role != null)
        {
            UpdateRoleViewModel model = new()
            {
                Id = role.Id,
                Name = role.Name
            };
        return View(model);
        }
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult Update(int id, UpdateRoleViewModel model)
    {
        var role = roleManager.FindByIdAsync(id.ToString()).Result;
        if (role != null)
        {
            role.Name = model.Name;

            var result = roleManager.UpdateAsync(role).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code,item.Description);
                }
            }
            return View(model);
        }
        return NotFound();
    }
    #endregion
    #region Delete
    public IActionResult Delete(int id)
    {
        var role = roleManager.FindByIdAsync(id.ToString()).Result;
        if(role != null)
        {
            var result = roleManager.DeleteAsync(role).Result;
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
    #endregion
}
