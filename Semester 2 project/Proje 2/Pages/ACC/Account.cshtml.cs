using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Proje_term.Pages.ACC;

public class AccountModel : PageModel
{
    [Authorize]
    public void OnGet()
    {
    }
}
