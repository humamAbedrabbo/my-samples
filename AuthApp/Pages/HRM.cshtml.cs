using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthApp.Pages
{
    [Authorize(Policy = "HR Manager")]
    public class HRMModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
