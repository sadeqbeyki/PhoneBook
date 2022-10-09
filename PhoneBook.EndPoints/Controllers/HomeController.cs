using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Contracts.People;
using PhoneBook.Domain.Core.People;
using PhoneBook.EndPoints.Models;
using System.Diagnostics;

namespace PhoneBook.EndPoints.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public HomeController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public IActionResult Index()
        {
            //_personRepository.Add(new Person
            //{
            //    FirstName = "Sadeq",
            //    LastName = "Beyki",
            //    Email = "mardibaki@gmail.com",
            //    Address = "Bolvar Keshavarz",
            //    Image = "My Image"
            //});
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}