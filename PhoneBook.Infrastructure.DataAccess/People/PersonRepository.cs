using PhoneBook.Core.Contracts.People;
using PhoneBook.Domain.Core.People;
using PhoneBook.Infrastructures.Common;
using PhoneBook.Infrastructures.DataLayer.Common;

namespace PhoneBook.Infrastructures.DataLayer.People
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(PhoneBookContext dbContext) : base(dbContext)
        {
        }
    }
}
