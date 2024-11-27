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
    public class IngredientRepositoryMongo : IRepository<Ingredient>
    {
        private MongoContext db;

        public IngredientRepositoryMongo(MongoContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Ingredient> GetList()
        {
            var builder = new FilterDefinitionBuilder<Ingredient>();
            var filter = builder.Empty;

            return new List<Ingredient>(db.IngredientCollection.Find(filter).ToList());
        }

        public Ingredient GetItem(int id)
        {
            return db.IngredientCollection.Find(i => i.Id == id).FirstOrDefault();

        }

        public void Create(Ingredient ingredient)
        {
            Ingredient last = db.IngredientCollection.Find(new FilterDefinitionBuilder<Ingredient>().Empty)
                .SortByDescending(i => i.Id).Limit(1).FirstOrDefault();
            ingredient.Id = last != null ? last.Id + 1 : 1;
            db.IngredientCollection.InsertOneAsync(ingredient);
        }

        public void Update(Ingredient ingredient)
        {
            db.IngredientCollection.ReplaceOneAsync(i => i.Id == ingredient.Id, ingredient);

        }

        public void Delete(int id)
        {
            db.IngredientCollection.DeleteOneAsync(i => i.Id == id);

        }
    }
}
