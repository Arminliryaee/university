using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsFac;
using System.ComponentModel.DataAnnotations;

namespace Proje_term.Pages.ACC;


public class SignUpModel : PageModel
{
    private readonly UserManager<CustomeIdentityUser> userManager;
    public SignUpModel(UserManager<CustomeIdentityUser> userManager) => this.userManager = userManager;
    [BindProperty]
    
    public string FirstName { get; set; }
    [BindProperty]
    
    public string LastName { get; set; }
    [BindProperty]
    
    [Phone]
    public string PhoneNumber { get; set; }
    [BindProperty]
    
    public string UserName { get; set; }
    [BindProperty]
    
    public string Password { get; set; }
    [BindProperty]
    [EmailAddress]    
    public string Email { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            CustomeIdentityUser user = new()
            {   
                UserName = UserName,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                Email = Email,

            };
            IdentityResult result = await userManager.CreateAsync(user, Password);
            if (result.Succeeded)
            { 
               return RedirectToPage("/ACC/Login"); 
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description); 
            }

        }
        return Page();
    }
}
