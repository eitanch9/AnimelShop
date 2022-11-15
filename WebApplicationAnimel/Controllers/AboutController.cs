using Microsoft.AspNetCore.Mvc;

namespace WebApplicationAnimel.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
