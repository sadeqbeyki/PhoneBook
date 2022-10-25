using Microsoft.AspNetCore.Identity;

namespace PhoneBook.EndPoints.Models.AAA
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
