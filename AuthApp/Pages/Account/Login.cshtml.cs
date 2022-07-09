using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace AuthApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credentials Credentials { get; set; } = new();

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid) 
                return Page();

            if(Credentials.UserName == "admin" && Credentials.Password == "123")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, Credentials.UserName),
                    new Claim(ClaimTypes.Email, "admin@mywebapp.com"),
                    new Claim("Admin", "true"),
                    new Claim("Manager", "true"),
                    new Claim("Department", "HR"),
                    //new Claim("EmploymentDate", "2022-07-01"),
                    new Claim("EmploymentDate", "2022-03-01"),

                };
                var identity = new ClaimsIdentity(claims, "MyAuth");
                var user = new ClaimsPrincipal(identity);
                var authProps = new AuthenticationProperties()
                {
                    // IsPersistent = true,
                    IsPersistent = Credentials.RememberMe,
                };
                await HttpContext.SignInAsync("MyAuth", user);
            }
            return RedirectToPage("/Index");
        }
    }

    public class Credentials
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
