using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.EndPoints.Controllers
{
    public class TagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
