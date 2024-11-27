using Microsoft.AspNetCore.Mvc;

namespace Lab5WebApp.Controllers
{
    public class AssortmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
