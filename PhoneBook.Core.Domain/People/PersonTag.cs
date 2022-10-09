using PhoneBook.Domain.Core.Tags;

namespace PhoneBook.Domain.Core.People
{
    public class PersonTag : BaseEntity
    {
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
