using BLL.Services;
using Interfaces.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5WebApp.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            
                Bind<IOrderService>().To<OrderService>();
            Bind<IReportService>().To<ReportService>();
            Bind<IOrderLineService>().To<OrderLinesService>();
            Bind<IUserService>().To<UserService>();
            Bind<IPizzaService>().To<PizzaService>();
            Bind<IIngredientService>().To<IngredientService>();


        }
    }
}
