using DomainModel;
using Interfaces.DTO;
using Interfaces.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Mocks
{
    public static class MockReportRepository
    {
        //static List<ReportData> data
        //    => MockPizzaRepository.pizzas.Where(i => i.Ingredients.Any(i => i.Id==id Select(i => new ReportData
        //    {
        //        Id = i.Id,
        //        Description = i.Description,
        //        Name = i.Name
        //    }).ToList();



        public static Mock<IReportsRepository> GetMock()
        {
            var mock = new Mock<IReportsRepository>();
            //var request = (from pizza in db.PizzaCollection.AsQueryable()
            //               join pi in db.PizzaIngredientCollection.AsQueryable()
            //               on pizza.Id equals pi.pizzaId
            //               join ingr
            //               in db.IngredientCollection.AsQueryable()
            //               on pi.ingredientId equals ingr.Id
            //               where ingr.Id == ingredientId
            //               select new ReportData()
            //               {
            //                   Id = pizza.Id,
            //                   Name = pizza.Name,
            //                   Description = pizza.Description
            //               }).ToList();
            //data = request;

            mock.Setup(m => m.PizzaWithIngredients(It.IsAny<int>()))
                .Returns((int id) => MockPizzaRepository.pizzas.Where(i => i.Ingredients.
                Any(i => i.Id == id)).Select(i => new ReportData
                {
                    Id = i.Id,
                    Description = i.Description,
                    Name = i.Name
                }).ToList());
            return mock;
        }
    }
}
