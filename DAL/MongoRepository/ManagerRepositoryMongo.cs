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
    public class ManagerRepositoryMongo :IRepository<Manager>
    {
        private MongoContext db;

        public ManagerRepositoryMongo(MongoContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Manager> GetList()
        {
            var builder = new FilterDefinitionBuilder<Manager>();
            var filter = builder.Empty;

            return new List<Manager>(db.ManagerCollection.Find(filter).ToList());
        }

        public Manager GetItem(int id)
        {
            return db.ManagerCollection.Find(i => i.Id == id).FirstOrDefault();

        }

        public void Create(Manager manager)
        {
            Manager last = db.ManagerCollection.Find(new FilterDefinitionBuilder<Manager>().Empty)
                .SortByDescending(i => i.Id).Limit(1).FirstOrDefault();
            manager.Id = last != null ? last.Id + 1 : 1;
            db.ManagerCollection.InsertOneAsync(manager);
        }

        public void Update(Manager manager)
        {
            db.ManagerCollection.ReplaceOneAsync(i => i.Id == manager.Id, manager);

        }

        public void Delete(int id)
        {
            db.ManagerCollection.DeleteOneAsync(i => i.Id == id);

        }
    }
}
