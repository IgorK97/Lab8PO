using BLL.Services;
using DTO;
using Interfaces.Services;
using Lab5WebApp.Models;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using System.Web.Mvc;

namespace Lab5WebApp.Controllers
{
    public class LinqReportController : Controller
    {
        IIngredientService ingredientService;
        IReportService reportService;
        IOrderLineService orderLineService;
        IPizzaService pizzaService;
        IOrderService orderService;
        LinqReportModel lrm;
        public LinqReportController(IIngredientService ingredientService, 
            IReportService reportService, IOrderLineService orderLineService,
            IPizzaService pizzaService, IOrderService orderService)
        {
            this.ingredientService = ingredientService;
            this.reportService = reportService;
            this.orderLineService = orderLineService;
            this.pizzaService = pizzaService;
            this.orderService = orderService;
            //lrm = new LinqReportModel()
            //{
            //    ReportData = new List<Interfaces.DTO.ReportData>(),
            //    SelectedIngredientId = 7,
            //    IngredientList = ingredientService.GetIngredients(null)
            //};
        }

        public ActionResult Create(int id)
        {
            OrderLineModel olm = new OrderLineModel(pizzaService.GetPizzaSizes(),
                ingredientService.GetIngredients(null), pizzaService.GetPizzas());
            olm.pizzaId = id;
            olm.Id = 0;
            olm.PizzaSize_Id = 1;
            decimal pr, we;
            (pr, we) = orderLineService.GetBasePriceAndWeight(1);
            
            decimal price, weight;
            //(price, weight) = orderLineService.GetBasePriceAndWeight(1);
            (price, weight) = olm.GetConcretePriceAndWeight(id, 1, 1);

            olm.position_price = price+pr;
            olm.weight = weight+we;
            olm.Name = olm.pizzas.Where(p => p.Id == id).Select(p => p.C_name).FirstOrDefault();
            return View(olm);
        }
        [HttpPost]
        public ActionResult CreateLine(OrderLineModel olm)
        {
            //if (ModelState.IsValid)
            //{
            
                List<IngredientDto> listedingr = new List<IngredientDto>();
                if (olm.addedingredients != null)
                    foreach (IngredientShortDto ingrm in olm.addedingredients)
                    {
                        IngredientDto ingredientDto = new IngredientDto
                        {
                            Id = ingrm.Id

                        };
                        listedingr.Add(ingredientDto);
                    }
                int Id = orderService.GetCurrentOrder(3);
                OrderLineDto oldto = new OrderLineDto()
                {
                    position_price = olm.position_price,
                    ordersId = (int)Id,
                    custom = false,
                    weight = olm.weight,
                    pizzaId = olm.pizzaId,
                    pizza_sizesId = 1,
                    quantity = 1,
                    addedingredients = listedingr,
                    Pizza = new PizzaDto
                    {
                        Id = olm.pizzaId
                    }
                };
                orderLineService.CreateOrderLine(oldto);
                return RedirectToAction("LinqReport");

            //}
            //else
            //{
            //    return RedirectToAction("LinqReport");

            //}
        }
        //lrm = new LinqReportModel()
        //    {
        //        ReportData = new List<Interfaces.DTO.ReportData>(),
        //        SelectedIngredientId = 7,
        //        IngredientList = ingredientService.GetIngredients(null)
        //    };
        //    return View("LinqReport", lrm);
        

        //[Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult LinqReport()
        {
            lrm = new LinqReportModel()
            {
                ReportData = new List<Interfaces.DTO.ReportData>(),
                SelectedIngredientId = 7,
                IngredientList = ingredientService.GetIngredients(null)
            };
            //ViewBag.list = lrm.IngredientList;

            //SelectList ingrs = new SelectList(lrm.IngredientList, "Id", "Name");
            return View(lrm);

        }
        [HttpPost]
        public ActionResult LinqReport(int ingrId)
        {
            //model.ReportData = reportService.ReportPhonesOfMunufacturer(model.SelectedManufId);
            //model.ManufList = phoneService.GetManufacturers();
            //if (ModelState.IsValid)
            //{
            //    //lrm = new LinqReportModel()
            //    //{
            //    //    ReportData = new List<Interfaces.DTO.ReportData>(),
            //    //    SelectedIngredientId = 7,
            //    //    IngredientList = ingredientService.GetIngredients(null)
            //    //};
            //    lrm.ReportData = reportService.ReportPizzas(lrm.SelectedIngredientId);
            //    lrm.IngredientList = ingredientService.GetIngredients(null);
            //    lrm.SelectedIngredientId = model.SelectedIngredientId;
            //    //return RedirectToAction("Index");
            //    //return View(lrm);
            //    return RedirectToAction("Index");
            //}
            //return View(model);
            lrm = new LinqReportModel()
            {
                ReportData = new List<Interfaces.DTO.ReportData>(),
                SelectedIngredientId = 7,
                IngredientList = ingredientService.GetIngredients(null)
            };
            lrm.ReportData = reportService.ReportPizzas(ingrId);
            return View(lrm); 
        }
    }
}
