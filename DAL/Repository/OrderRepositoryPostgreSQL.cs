using DomainModel;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class OrderRepositoryPostgreSQL :IRepository<Order>
    {
        private PizzaDeliveryContext db;

        public OrderRepositoryPostgreSQL(PizzaDeliveryContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Order> GetList()
        {
            return db.Orders.Include(o => o.OrderLines).ThenInclude(ol =>
            ol.Pizza).ThenInclude(p => p.Ingredients).Include(o => o.OrderLines)
            .ThenInclude(ol => ol.Ingredients).ToList();
        }

        public Order GetItem(int id)
        {
            return db.Orders.Include(o => o.OrderLines).ThenInclude(ol => ol.Pizza)
                 .ThenInclude(p => p.Ingredients).Include(o => o.OrderLines)
                 .ThenInclude(ol => ol.Ingredients)
                 .FirstOrDefault(u => u.Id == id);
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            db.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }
    }
}
