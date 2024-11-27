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
    public class PizzaSizeRepositoryMongo :IRepository<PizzaSize>
    {
        private MongoContext db;

        public PizzaSizeRepositoryMongo(MongoContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<PizzaSize> GetList()
        {
            var builder = new FilterDefinitionBuilder<PizzaSize>();
            var filter = builder.Empty;

            return new List<PizzaSize>(db.PizzaSizeCollection.Find(filter).ToList());
        }

        public PizzaSize GetItem(int id)
        {
            return db.PizzaSizeCollection.Find(i => i.Id == id).FirstOrDefault();
        }

        public void Create(PizzaSize pizzasize)
        {
            PizzaSize last = db.PizzaSizeCollection.Find(new FilterDefinitionBuilder<PizzaSize>().Empty)
                .SortByDescending(i => i.Id).Limit(1).FirstOrDefault();
            pizzasize.Id = last != null ? last.Id + 1 : 1; 
            db.PizzaSizeCollection.InsertOneAsync(pizzasize);
        }

        public void Update(PizzaSize pizzasize)
        {
            db.PizzaSizeCollection.ReplaceOneAsync(i => i.Id == pizzasize.Id, pizzasize);
        }

        public void Delete(int id)
        {
            db.PizzaSizeCollection.DeleteOneAsync(i => i.Id == id);
        }
    }
}
