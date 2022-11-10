using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook.EndPoints.Models.AAA
{
    public class UserDbContext : IdentityDbContext<AppUser, PBIdentityRole, int>
    {
        public DbSet<BadPassword> BadPasswords { get; set; }
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
