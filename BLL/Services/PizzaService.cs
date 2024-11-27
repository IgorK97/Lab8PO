using DTO;
using Interfaces.Repository;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PizzaService :IPizzaService
    {
        private IDbRepos dbr;
        //private PizzaDeliveryContext db;
        public PizzaService(IDbRepos repos)
        {
            dbr = repos;
            //db = new PizzaDeliveryContext();
        }
        public bool Save()
        {
            if (dbr.Save() > 0) return true;
            return false;
        }
        public List<PizzaDto> GetPizzas()
        {
            return dbr.Pizzas.GetList().Select(i => new PizzaDto(i)).ToList();
        }

        public List<PizzaSizesDto> GetPizzaSizes()
        {
            return dbr.PizzaSizes.GetList().Select(i => new PizzaSizesDto(i)).ToList();
        }
    }
}
