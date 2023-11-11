using Microsoft.AspNetCore.Mvc;

namespace DotNetSixMvcAssignment.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
