using PhoneBook.Core.Contracts.Phones;
using PhoneBook.Domain.Core.Phones;
using PhoneBook.Infrastructures.Common;
using PhoneBook.Infrastructures.DataLayer.Common;

namespace PhoneBook.Infrastructures.DataLayer.Phones
{
    public class PhoneRepository : BaseRepository<Phone>, IPhoneRepository
    {
        public PhoneRepository(PhoneBookContext dbContext) : base(dbContext)
        {
        }
    }
}
