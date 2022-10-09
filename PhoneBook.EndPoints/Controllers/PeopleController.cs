using Microsoft.AspNetCore.Mvc;
using PhoneBook.Domain.Core.People;

namespace PhoneBook.EndPoints.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Person person)
        {
            return View();
        }
    }
}
