using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class BookingModel : PageModel
    {
        public int TotalPrice { get; set; }
        public void OnGet()
        {
            TempData["Total"] = TotalPrice;
            System.Console.WriteLine(TempData["Total"]?.ToString() ?? "");

        }

        public void OnPost()
        {
            // Obtener el valor del formulario
          
        }
    }
    
    }
