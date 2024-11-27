using DomainModel;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MongoRepository
{
    public class OrderLineRepositoryMongo :IRepository<OrderLine>
    {
        private MongoContext db;

        public OrderLineRepositoryMongo(MongoContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<OrderLine> GetList()
        {
            var builder = new FilterDefinitionBuilder<OrderLine>();
            var filter = builder.Empty;

            return new List<OrderLine>(db.OrderLineCollection.Find(filter).ToList());
        }

        public OrderLine GetItem(int id)
        {
            return db.OrderLineCollection.Find(i => i.Id == id).FirstOrDefault();

        }

        public void Create(OrderLine orderline)
        {
            OrderLine last = db.OrderLineCollection.Find(new FilterDefinitionBuilder<OrderLine>().Empty)
                .SortByDescending(i => i.Id).Limit(1).FirstOrDefault();
            orderline.Id = last != null ? last.Id + 1 : 1;
            db.OrderLineCollection.InsertOneAsync(orderline); ;
        }

        public void Update(OrderLine orderline)
        {
            db.OrderLineCollection.ReplaceOneAsync(i => i.Id == orderline.Id, orderline);

        }

        public void Delete(int id)
        {
            db.OrderLineCollection.DeleteOneAsync(i => i.Id == id);

        }
    }
}
