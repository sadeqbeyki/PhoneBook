using Microsoft.AspNetCore.Identity;

namespace PhoneBook.EndPoints.Models.AAA
{
    //Interface Phone Book Password Validator
    public class IPBPasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            List<IdentityError> errors = new();
            if (user.UserName == password || user.UserName.Contains(password))
            {
                errors.Add(new IdentityError
                {
                    Code = "Password",
                    Description = "Password is equal to username"
                });
            }
            return Task.FromResult(errors.Any() ?
                IdentityResult.Failed(errors.ToArray()) :
                IdentityResult.Success);
        }
    }
}
