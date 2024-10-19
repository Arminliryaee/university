using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsFac;
using System.ComponentModel.DataAnnotations;

namespace Proje_term.Pages.ACC;

public class UpdateACCModel : PageModel
{

    private readonly UserManager<CustomeIdentityUser> userManager;
    public UpdateACCModel(UserManager<CustomeIdentityUser> userManager) => this.userManager = userManager;
    public string Id { get; set; }
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

    public async Task OnGet(string id)
    {
        var UUser = await userManager.FindByIdAsync(id);
        if (UUser != null) 
        {
            FirstName = UUser.FirstName;
            LastName = UUser.LastName;
            PhoneNumber = UUser.PhoneNumber;
        }
          
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            var UUser = await userManager.FindByIdAsync(Id);
            if (UUser != null)
            {
                FirstName = UUser.FirstName;
                LastName = UUser.LastName;
                PhoneNumber = UUser.PhoneNumber;

                var result = await userManager.UpdateAsync(UUser);
                if (result.Succeeded && !string.IsNullOrEmpty(Password))
                {
                    await userManager.RemovePasswordAsync(UUser);
                    result = await userManager.AddPasswordAsync(UUser, Password);
                }
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var i in result.Errors)
                {
                    ModelState.AddModelError("", i.Description);
                }
            }
        }
        return Page();
    }

}


