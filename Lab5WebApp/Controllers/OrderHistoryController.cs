using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab5WebApp.Controllers
{
    public class OrderHistoryController : Controller
    {
        //IPhoneService phoneService;
        IOrderService orderServ;
        public OrderHistoryController(/*IPhoneService crudDb, */IOrderService orderservice)
        {
            orderServ = orderservice;
        }
        public IActionResult Index()
        {
            var items = orderServ.GetAllOrders(3);
            return View(items);
        }
        public ActionResult Cancel(int id)
        {
            orderServ.CancelOrder(id);
            return RedirectToAction("Index");
        }
    }
}
