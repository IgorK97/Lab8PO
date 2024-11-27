using DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5WebApp.Models
{
    public class PizzaModel
    {
        public PizzaModel()
        {

        }
        [Key]
        public int Id { get; set; }
        [DisplayName("Название")]
        [Required]
        public string C_name { get; set; }

        public bool active { get; set; }

        public string description { get; set; }
        public byte[]? pizzaimage { get; set; }

        public List<IngredientModel> listedingredients { get; set; }

        //public PizzaModel(Pizza p)
        //{
        //    Id = p.Id;
        //    C_name = p.Name;
        //    active = p.Active;
        //    description = p.Description;
        //    pizzaimage = p.Pizzaimage;
        //    listedingredientsIds = p.Ingredients.Select(i => i.Id).ToList();
        //}
    }
}
