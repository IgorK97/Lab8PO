using DomainModel;
using DTO;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MongoRepository
{
    public class OrderRepositoryMongo :IRepository<Order>
    {
        private MongoContext db;

        public OrderRepositoryMongo(MongoContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Order> GetList()
        {
            var builder = new FilterDefinitionBuilder<Order>();
            var filter = builder.Empty;

            return new List<Order>(db.OrderCollection.Find(filter).ToList());
        }

        public Order GetItem(int id)
        {
            Order o = db.OrderCollection.Find(i => i.Id == id).FirstOrDefault();
            List<OrderLine> odtolines = db.OrderLineCollection.AsQueryable()
                .ToList().Where(i =>
            i.OrdersId == id).ToList();
            List<OrderLine> odtolines_new = new List<OrderLine>();
            foreach(OrderLine line in odtolines)
            {
                OrderLine ordto = line;
                Pizza pdto = db.PizzaCollection.AsQueryable().ToList()
                    .Where(i => i.Id == line.PizzaId).FirstOrDefault();
                
                List<Ingredient> ingrs = (from ingr in db.IngredientCollection.AsQueryable()
                         join pi in db.PizzaIngredientCollection.AsQueryable()
                         on ingr.Id equals pi.ingredientId
                         where pi.pizzaId == id
                         select new Ingredient
                         {
                             Id = ingr.Id,
                             PricePerGram = ingr.PricePerGram,
                             Active = ingr.Active,
                             Big = ingr.Big,
                             Medium = ingr.Medium,
                             Small = ingr.Small,
                             Ingrimage = ingr.Ingrimage,
                             Name = ingr.Name
                         }).ToList();
                pdto.Ingredients = ingrs;
                ordto.Pizza = pdto;
                odtolines_new.Add(ordto);
            }
            o.OrderLines = odtolines_new;
            return o;
        }

        public void Create(Order order)
        {
            Order last = db.OrderCollection.Find(new FilterDefinitionBuilder<Order>().Empty)
                .SortByDescending(i => i.Id).Limit(1).FirstOrDefault();
            order.Id = last != null ? last.Id + 1 : 1;
            db.OrderCollection.InsertOneAsync(order);
        }

        public void Update(Order order)
        {
            db.OrderCollection.ReplaceOneAsync(i => i.Id == order.Id, order);

        }

        public void Delete(int id)
        {
            db.OrderCollection.DeleteOneAsync(i => i.Id == id);

        }
    }
}
