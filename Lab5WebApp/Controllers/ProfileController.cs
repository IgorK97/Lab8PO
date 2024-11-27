using Microsoft.AspNetCore.Mvc;

namespace Lab5WebApp.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
