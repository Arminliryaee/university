using Microsoft.AspNetCore.Identity;
using ModelsFac;

namespace Proje_term.Validators
{
    public class PasswordVaidator : IPasswordValidator<CustomeIdentityUser>
    {
        
        public Task<IdentityResult> ValidateAsync(UserManager<CustomeIdentityUser> manager, CustomeIdentityUser user, string? password)
        {
            if (password.Contains(user.UserName , StringComparison.OrdinalIgnoreCase)) 
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "username in password",
                    Description = " you cant use your username in password"
                }));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
