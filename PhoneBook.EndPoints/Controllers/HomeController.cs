using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Contracts.People;
using PhoneBook.Domain.Core.People;
using PhoneBook.EndPoints.Models;
using System.Diagnostics;

namespace PhoneBook.EndPoints.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}