using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Dot_Net_Security.Pages.Account
{
    public class LoginModel : PageModel
    {
        public class credientails
        {
            [Required]
            public string UserName { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string  PassWord { get; set; }
        }
        [BindProperty]
        public credientails Credientails { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            
            if(Credientails.UserName == "Admin" && Credientails.PassWord == "admin@123")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,"Admin"),
                    new Claim(ClaimTypes.Email,"Admin@a.com")
                };

                var identity = new ClaimsIdentity(claims,"AUTH");
                ClaimsPrincipal Claim_Principle = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("AUTH",Claim_Principle);

                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
