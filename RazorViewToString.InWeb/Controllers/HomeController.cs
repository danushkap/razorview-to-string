using Microsoft.AspNetCore.Mvc;
using RazorViewToString.InWeb.Models;
using System.Threading.Tasks;

namespace RazorViewToString.InWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly RazorViewToStringRenderer _razorViewToStringRenderer;

        public HomeController(RazorViewToStringRenderer razorViewToStringRenderer)
        {
            _razorViewToStringRenderer = razorViewToStringRenderer;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.StringOutput = await _razorViewToStringRenderer
                .RenderViewToStringAsync(
                    @"Views\Profile.cshtml",
                    new ProfileModel
                    {
                        FirstName = "Danushka",
                        LastName = "Padukka"
                    });

            return View("~/Views/Index.cshtml");
        }
    }
}
