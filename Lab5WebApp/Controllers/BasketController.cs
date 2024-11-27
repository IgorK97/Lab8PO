using BLL.Services;
using DTO;
using Interfaces.Services;
using Lab5WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab5WebApp.Controllers
{
    public class BasketController : Controller
    {
        IOrderLineService orderLineService;
        IOrderService orderService;
        int currentOrderId;
        IEnumerable<OrderLineDto> orderlines;
        OrderModel model;
        public BasketController(IOrderLineService orderLineService, IOrderService orderService)
        {
            this.orderLineService = orderLineService;
            this.orderService = orderService;
        }

        public IActionResult Index()
        {
            currentOrderId = orderService.GetCurrentOrder(3);
            OrderDto odto = orderService.RetOrder(currentOrderId);
            //orderlines = orderLineService.GetAllOrderLines(currentOrderId);
            //List<OrderLineModel> orderlines1 = new List<OrderLineModel>();
            //foreach
            //OrderModel = new OrderModel()
            //{
            //    listedlines = orderlines1
            //};
            //return View(orderlines);
            return View(odto);
        }
        public ActionResult Cancel(int id)
        {
            orderLineService.DeleteOrderLine(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult MakeOrder(OrderDto o)
        {
            if (o.address_del == null)
                o.address_del = "";
            orderService.SubmitOrder((int)o.Id, o.address_del);
            currentOrderId = orderService.GetCurrentOrder(3);
            OrderDto odto = orderService.RetOrder(currentOrderId);
            return RedirectToAction("Index", odto);
        }
    }
}
