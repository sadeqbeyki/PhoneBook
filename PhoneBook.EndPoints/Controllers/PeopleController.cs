using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Contracts.People;
using PhoneBook.Core.Contracts.Tags;
using PhoneBook.Domain.Core.People;
using PhoneBook.EndPoints.Models.People;
using System.ComponentModel;

namespace PhoneBook.EndPoints.Controllers
{
    //[Authorize]
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
            var people = _personRepository.GetAll().ToList();
            return View(people);
        }

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            PersonAndTagsViewModel model = new()
            {
                TagsForDisplay = _tagRepository.GetAll().ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CreatePersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                Person person = new()
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
                #region Image
                if (model?.Image?.Length > 0)
                {
                    using var memoryStream = new MemoryStream();
                    model.Image.CopyTo(memoryStream);
                    var fileByte = memoryStream.ToArray();
                    person.Image = Convert.ToBase64String(fileByte);
                }
                #endregion
                _personRepository.Create(person);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        #endregion

        #region Update
        [HttpGet]
        public IActionResult Update(int id)
        {
            var person = _personRepository.Get(id);
            if (person != null)
            {
                UpdatePersonViewModel model = new()
                {
                    Id = id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Email = person.Email,
                    Address = person.Address,
                    //SelectedTags = new List<PersonTag>(person.Tags.Select(x => new PersonTag
                    //{
                    //    TagId = x
                    //}).ToList())
                    //Image = person.Image(Convert.FromBase64String(fileByte)),
                };
                return View(model);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Update(int id, UpdatePersonViewModel model)
        {
            var person = _personRepository.Get(id);
            if (person != null)
            {
                person.FirstName = model.FirstName;
                person.LastName = model.LastName;
                person.Email = model.Email;
                person.Address = model.Address;

            }

            return View(model);
        }
        #endregion

    }
}
