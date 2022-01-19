using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dot_Net_Security.Pages
{
    [Authorize(Policy = "HR")]
    public class HRModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
