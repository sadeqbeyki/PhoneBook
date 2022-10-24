﻿using Microsoft.AspNetCore.Identity;

namespace PhoneBook.EndPoints.Models.AAA
{
    public class PBUserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            List<IdentityError> errors = new();

            //if (!user.Email.EndsWith("@nikamooz.com"))
            //{
            //    errors.Add(new IdentityError
            //    {
            //        Code = "InvalidEmail",
            //        Description = "Use nikamooz email for Registration"
            //    });
            //}

            return Task.FromResult(errors.Any() ?
                    IdentityResult.Failed(errors.ToArray()) :
                    IdentityResult.Success);
        }
    }
}
