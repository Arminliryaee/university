using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsFac;

namespace Proje_term.Pages.ACC;

public class LoginModel : PageModel
{
    private readonly SignInManager<CustomeIdentityUser> manager;
    [BindProperty]
    public string Username { get; set; }
    [BindProperty]
    public string Password { get; set; }
    [BindProperty]
    public string? ReturnUrl { get; set; }
    public LoginModel(SignInManager<CustomeIdentityUser> manager)
    {
        this.manager = manager;
    }
    public void OnGet()
    {
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid) 
        {
            var result = await manager.PasswordSignInAsync(Username, Password, false, false);
            if (result.Succeeded) 
            {
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError("", "inavlid password or username");
            }

        }
        return Page();
    }

}
