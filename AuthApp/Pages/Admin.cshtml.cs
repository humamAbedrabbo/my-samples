using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthApp.Pages
{
    [Authorize(Policy = "AdminOnly")]
    public class AdminModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
