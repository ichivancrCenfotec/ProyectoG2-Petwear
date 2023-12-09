using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class BookingModel : PageModel
    {
        public int TotalPrice { get; set; }
        public void OnGet()
        {
      

        }

        public void OnPost()
        {
            TempData["Total"] = TotalPrice;
            System.Console.WriteLine(TempData["Total"]?.ToString() ?? "");

        }
    }
    
    }
