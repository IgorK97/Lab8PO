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
    public class ClientRepositoryMongo :IRepository<Client>
    {
        private MongoContext db;

        public ClientRepositoryMongo(MongoContext dbcontext)
        {
            db = dbcontext;
        }

        public List<Client> GetList()
        {
            var builder = new FilterDefinitionBuilder<Client>();
            var filter = builder.Empty;

            return new List<Client>(db.ClientCollection.Find(filter).ToList());
        }

        public Client GetItem(int id)
        {
            return db.ClientCollection.Find(i => i.Id == id).FirstOrDefault();

        }

        public void Create(Client client)
        {
            Client last = db.ClientCollection.Find(new FilterDefinitionBuilder<Client>().Empty)
                .SortByDescending(i => i.Id).Limit(1).FirstOrDefault();
            client.Id = last != null ? last.Id + 1 : 1;
            db.ClientCollection.InsertOneAsync(client);
        }

        public void Update(Client client)
        {
            db.ClientCollection.ReplaceOneAsync(i => i.Id == client.Id, client);

        }

        public void Delete(int id)
        {
            db.ClientCollection.DeleteOneAsync(i => i.Id == id);

        }
    }
}
