using PhoneBook.Domain.Core.Phones;

namespace PhoneBook.Domain.Core.People
{
    public class Person: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public List<Phone> Phones { get; set; }
        public List<PersonTag> Tags { get; set; }
    }
}
