using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthApp.Pages.Account
{
    [Authorize]
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext.SignOutAsync("MyAuth");
            return RedirectToPage("/Index");
        }
    }
}
