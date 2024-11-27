using DomainModel;
using Interfaces.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MongoRepository
{
    public class CourierRepositoryMongo :IRepository<Courier>
    {
        private MongoContext db;

        public CourierRepositoryMongo(MongoContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Courier> GetList()
        {
            var builder = new FilterDefinitionBuilder<Courier>();
            var filter = builder.Empty;

            return new List<Courier>(db.CourierCollection.Find(filter).ToList());
        }

        public Courier GetItem(int id)
        {
            return db.CourierCollection.Find(i => i.Id == id).FirstOrDefault();

        }

        public void Create(Courier courier)
        {
            Courier last = db.CourierCollection.Find(new FilterDefinitionBuilder<Courier>().Empty)
                .SortByDescending(i => i.Id).Limit(1).FirstOrDefault();
            courier.Id = last != null ? last.Id + 1 : 1;
            db.CourierCollection.InsertOneAsync(courier);
        }

        public void Update(Courier courier)
        {
            db.CourierCollection.ReplaceOneAsync(i => i.Id == courier.Id, courier);

        }

        public void Delete(int id)
        {
            db.CourierCollection.DeleteOneAsync(i => i.Id == id);

        }
    }
}
