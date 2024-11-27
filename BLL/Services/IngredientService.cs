using DTO;
using Interfaces.Repository;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.Services.OrderLinesService;

namespace BLL.Services
{
    public class IngredientService : IIngredientService
    {
        private IDbRepos dbr;
        //private PizzaDeliveryContext db;
        public IngredientService(IDbRepos repos)
        {
            dbr = repos;
            //db = new PizzaDeliveryContext();
        }
        public bool Save()
        {
            if (dbr.Save() > 0) return true;
            return false;
        }
        public List<IngredientShortDto> GetIngredients(int? ps = null)
        {
            if (ps == null)
                ps = (int)PizzaSizeEnum.Small;
            var res = dbr.Ingredients.GetList().Select(i => new IngredientShortDto
            {
                Id = i.Id,
                C_name = i.Name,
                price = ps == (int)PizzaSizeEnum.Small ? i.PricePerGram * i.Small : ps == (int)PizzaSizeEnum.Medium ?
                i.PricePerGram * i.Medium : i.PricePerGram * i.Big,
                weight = ps == (int)PizzaSizeEnum.Small ? i.Small : ps == (int)PizzaSizeEnum.Medium ?
                i.Medium : i.Big,
                active = false,
                ingrimage = i.Ingrimage
            }).ToList();
            //var blres = new BindingList<IngredientShortDto>(res);
            return res;
        }

        public List<IngredientShortDto> GetConcreteIngredients(int ps, int ol_id)
        {


            var res = dbr.Ingredients.GetList().Select(i => new IngredientShortDto
            {
                Id = i.Id,
                C_name = i.Name,
                price = ps == (int)PizzaSizeEnum.Small ? i.PricePerGram * i.Small : ps == (int)PizzaSizeEnum.Medium ?
                    i.PricePerGram * i.Medium : i.PricePerGram * i.Big,
                weight = ps == (int)PizzaSizeEnum.Small ? i.Small : ps == (int)PizzaSizeEnum.Medium ?
                    i.Medium : i.Big,
                active = i.OrderLines.Any(ol => ol.Id == ol_id),
                ingrimage = i.Ingrimage

            }).ToList();
            //var blres = new BindingList<IngredientShortDto>(res);
            return res;
        }
    }
}
