using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsFac;

namespace Proje_term.Pages.ACC
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<CustomeIdentityUser> manager;

        public LogoutModel(SignInManager<CustomeIdentityUser> manager)
        {
            this.manager = manager;
        }
        public async Task<IActionResult> OnGet()
        {
            await manager.SignOutAsync();
            return Redirect("/");
        }
    }
}

