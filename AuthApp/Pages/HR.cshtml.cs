using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthApp.Pages
{
    [Authorize(Policy = "HROnly")]
    public class HRModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
