using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel;
using System.Text;
using System.Threading.Tasks;

namespace Lab5WebApp.Models
{
    public class PizzaSizes
    {
        public PizzaSizes()
        {

        }
        public PizzaSizes(PizzaSize ps)
        {
            Id = ps.Id;
            name = ps.Name;
            price = ps.Price;
            weight = ps.Weight;
        }

        public int Id { get; set; }

        public string name { get; set; }

        public decimal price { get; set; }

        public decimal weight { get; set; }
    }
}
