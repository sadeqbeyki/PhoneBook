using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Contracts.People;
using PhoneBook.Core.Contracts.Tags;
using PhoneBook.Domain.Core.People;
using PhoneBook.EndPoints.Models.People;

namespace PhoneBook.EndPoints.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ITagRepository _tagRepository;
        private readonly IPersonRepository _personRepository;

        public PeopleController(ITagRepository tagRepository, IPersonRepository personRepository)
        {
            _tagRepository = tagRepository;
            _personRepository = personRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            AddPersonDisplayViewModel model = new AddPersonDisplayViewModel();
            model.TagsForDisplay = _tagRepository.GetAll().ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(AddPersonGetViewModel model)
        {
            if (ModelState.IsValid)
            {
                Person person = new Person
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Address = model.Address,
                    Tags = new List<PersonTag>(model.SelectedTags.Select(c => new PersonTag
                    {
                        TagId = c
                    }).ToList())
                };
                if (model.Image.Length > 0)
                {
                    using(var ms = new MemoryStream())
                    {
                        model.Image.CopyTo(ms);
                        var fileByte=ms.ToArray();
                        person.Image=Convert.ToBase64String(fileByte);
                    }
                }
                _personRepository.Add(person);
                return RedirectToAction("Index");
        }
            return View();
    }
}
}
