using DomainModel;
using Interfaces.DTO;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MongoRepository
{
    public class ReportRepositoryMongo : IReportsRepository
    {
        private MongoContext db;
        
        public ReportRepositoryMongo(MongoContext dbcontext)
        {
            this.db = dbcontext;
        }
        class OrdersBM
        {
            public int order_id;
            public DateTime dt;
            public int courier_id;
        }
        public List<OrdersByMonth> ExecuteSP(int month, int year, int ClientId)
        {
            var builder = new FilterDefinitionBuilder<Pizza>();
            var filter = builder.Empty;
            var project = BsonDocument.Parse("{ClientId: '$ClientId', CourierId: '$CourierId', OrderId: '$Id', Ordertime:'$Ordertime', month:{$month: '$Ordertime'}, year: {$year: '$Ordertime'}}");
            var fil = BsonDocument.Parse(
                "{$and:[{'month':{$eq: " + month + "}},{'year':{$eq:" + year + "}}]}");
            var res = db.OrderCollection.Aggregate()
                .Project(project)
                .Match(fil)
                .ToList()
                .Select(i => new OrdersBM
                {
                    order_id = i.GetValue("_id").ToInt32(),
                    dt = i.GetValue("Ordertime").ToLocalTime(),
                    courier_id = i.GetValue("CourierId").ToInt32()
                }).Select(i => new OrdersByMonth
                {

                    order_id = i.order_id.ToString(),
                    Date = i.dt,
                    courier_id = db.CourierCollection.AsQueryable().Where(c =>
                    c.Id == i.courier_id).Select(c => new
                    {
                        FIO =  c.LastName + " " + c.FirstName + " " + c.Surname
                    }).FirstOrDefault().FIO
                });
            return res.ToList();
            //NpgsqlParameter param1 = new NpgsqlParameter("month", NpgsqlTypes.NpgsqlDbType.Integer);
            //NpgsqlParameter param2 = new NpgsqlParameter("year", NpgsqlTypes.NpgsqlDbType.Integer);
            //param1.Value = month;
            //param2.Value = year;

            ////var result = dbContext.Database.SqlQuery<ParResult>("select * from _GetOrdersByMonthYear(@month, @year)", new object[] { param1, param2 }).ToList();
            ////var result = dbContext.Database.SqlQuery<int>($"select * from _GetOrdersByMonthYear(@month={param1}, @year={param2})").ToList();

            //var result = db.Orders.FromSql($"select * from getordersbymonthandyearnew({param1}, {param2})").ToList();

            //var data = result.Where(i => i.ClientId == ClientId && i.CourierId != null).Select(j =>
            //new OrdersByMonth
            //{
            //    order_id = j.Id,
            //    courier_id = db.Couriers.Where(c =>
            //c.Id == j.CourierId).Select(c => new
            //{
            //    fname = c.FirstName + " " + c.LastName + " " + c.Surname
            //}).FirstOrDefault().fname,
            //    Date = j.Ordertime
            //}).OrderByDescending(c => c.Date).ToList();

            //return data;
        }
        public List<ReportData> PizzaWithIngredients(int? ingredientId)
        {
            if (ingredientId != null)
            {
                //var request = db.PizzaCollection.AsQueryable().Where(p => p.Ingredients.Any(i => i.Id == ingredientId))
                //.Select(p => new ReportData
                //{
                //    Id = p.Id,
                //    Name = p.Name,
                //    Description = p.Description
                //}).ToList();
                //return request;
                var request = (from pizza in db.PizzaCollection.AsQueryable()
                               join pi in db.PizzaIngredientCollection.AsQueryable()
                               on pizza.Id equals pi.pizzaId
                               join ingr
                               in db.IngredientCollection.AsQueryable()
                               on pi.ingredientId equals ingr.Id
                               where ingr.Id == ingredientId
                               select new ReportData()
                               {
                                   Id = pizza.Id,
                                   Name = pizza.Name,
                                   Description = pizza.Description
                               }).ToList();
                return request;
            }
            var req = db.PizzaCollection.AsQueryable().Select(p => new ReportData
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
            }).ToList();
            return req;
            //if (ingredientId != null)
            //{
            //    var request = db.Pizzas.Where(p => p.Ingredients.Any(i => i.Id == ingredientId))
            //    .Select(p => new ReportData
            //    {
            //        Id = p.Id,
            //        Name = p.Name,
            //        Description = p.Description

            //    }).ToList();
            //    return request;
            //}
            //var request1 = db.Pizzas.Select(p => new ReportData
            //{
            //    Id = p.Id,
            //    Name = p.Name,
            //    Description = p.Description

            //}).ToList();
            //return request1;
        }

        //выполнить ХП
        

        
    }
}
