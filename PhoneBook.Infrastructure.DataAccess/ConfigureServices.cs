using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Core.Contracts.People;
using PhoneBook.Core.Contracts.Phones;
using PhoneBook.Core.Contracts.Tags;
using PhoneBook.Infrastructures.DataLayer.Common;
using PhoneBook.Infrastructures.DataLayer.People;
using PhoneBook.Infrastructures.DataLayer.Phones;
using PhoneBook.Infrastructures.DataLayer.Tags;
 
namespace PhoneBook.Infrastructure.DataAccess
{
    public static class ConfigureServices
    {
        public static void Configure(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<ITagRepository, TagRepository>();

            services.AddDbContext<PhoneBookContext>(x => x.UseSqlServer(connectionString));

        }
    }
}
