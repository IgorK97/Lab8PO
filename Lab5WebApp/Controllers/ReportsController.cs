using BLL.Services;
using Interfaces.Services;
using Lab5WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Lab5WebApp.Controllers
{
    public class ReportsController : Controller
    {
        IIngredientService ingredientService;
        IReportService reportService;
        public ReportsController(IIngredientService ingredientService, IReportService reportService)
        {
            this.ingredientService = ingredientService;
            this.reportService = reportService;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        //public ActionResult LinqReport()
        //{
        //    return View(new LinqReportModel() { SelectedIngredientId = 7, IngredientList = ingredientService.GetIngredients(null) });



        //}
        public IActionResult Index()
        {
            return View(new LinqReportModel() { SelectedIngredientId = 7, IngredientList = ingredientService.GetIngredients(null) });
        }
        [HttpPost]
        public ActionResult LinqReport(LinqReportModel model)
        {
            //model.ReportData = reportService.ReportPhonesOfMunufacturer(model.SelectedManufId);
            //model.ManufList = phoneService.GetManufacturers();
            if (ModelState.IsValid)
            {
                model.ReportData = reportService.ReportPizzas(model.SelectedIngredientId);
                model.IngredientList = ingredientService.GetIngredients(null);
                return View(model);
            }
            return View(model);
        
        }
        public ActionResult SPReport()
        {
            return View(new SPReportModel()
            {
                SelectedMonth = 10,
                SelectedYear = 2024
            });
        }
        [HttpPost]
        public ActionResult SPReport(SPReportModel model)
        {
            model.ReportData = reportService.ExecuteSP(model.SelectedMonth, model.SelectedYear, 3);
            return View(model);
        }
    }
}
