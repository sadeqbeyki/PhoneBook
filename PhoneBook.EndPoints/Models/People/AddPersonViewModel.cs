using PhoneBook.Domain.Core.Tags;
using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.EndPoints.Models.People
{
    public abstract class PersonViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(500, MinimumLength = 50)]
        public string Address { get; set; }
        public IFormFile Image { get; set; }
    }


    public class PersonAndTagsViewModel : PersonViewModel
    {
        public List<Tag> TagsForDisplay { get; set; }

    }

    public class CreatePersonViewModel : PersonViewModel
    {
        //public List<Tag> TagsForDisplay { get; set; }

        public List<int> SelectedTags { get; set; }
    }
    public class UpdatePersonViewModel : PersonAndTagsViewModel
    {
        public int Id { get; set; }
        public List<int> SelectedTags { get; set; }
    }
}
