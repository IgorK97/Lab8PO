﻿using DomainModel;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class OrderLineRepositoryPostgreSQL :IRepository<OrderLine>
    {
        private PizzaDeliveryContext db;

        public OrderLineRepositoryPostgreSQL(PizzaDeliveryContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<OrderLine> GetList()
        {
            return db.OrderLines.Include(o => o.Pizza).Include(o => o.Ingredients).ToList();
        }

        public OrderLine GetItem(int id)
        {
            return db.OrderLines.Include(o => o.Pizza).Include(o => o.Ingredients)
                .FirstOrDefault(u => u.Id == id);
        }

        public void Create(OrderLine orderline)
        {
            db.OrderLines.Add(orderline);
        }

        public void Update(OrderLine orderline)
        {
            db.Entry(orderline).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            OrderLine orderline = db.OrderLines.Find(id);
            if (orderline != null)
                db.OrderLines.Remove(orderline);
        }
    }
}
