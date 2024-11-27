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
    public class DelStatusRepositoryMongo :IRepository<DelStatus>
    {
        private MongoContext db;

        public DelStatusRepositoryMongo(MongoContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<DelStatus> GetList()
        {
            var builder = new FilterDefinitionBuilder<DelStatus>();
            var filter = builder.Empty;

            return new List<DelStatus>(db.DelStatusCollection.Find(filter).ToList());
        }

        public DelStatus GetItem(int id)
        {
            return db.DelStatusCollection.Find(i => i.Id == id).FirstOrDefault();

        }

        public void Create(DelStatus ds)
        {
            DelStatus last = db.DelStatusCollection.Find(new FilterDefinitionBuilder<DelStatus>().Empty)
                .SortByDescending(i => i.Id).Limit(1).FirstOrDefault();
            ds.Id = last != null ? last.Id + 1 : 1;
            db.DelStatusCollection.InsertOneAsync(ds);
        }

        public void Update(DelStatus ds)
        {
            db.DelStatusCollection.ReplaceOneAsync(i => i.Id == ds.Id, ds);

        }

        public void Delete(int id)
        {
            db.DelStatusCollection.DeleteOneAsync(i => i.Id == id);

        }
    }
}
