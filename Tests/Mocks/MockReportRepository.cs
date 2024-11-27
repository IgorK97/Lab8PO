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
        static List<ReportData> data
            => MockPizzaRepository.pizzas.Select(i => new ReportData
            {
                Id = i.Id,
                Description = i.Description,
                Name = i.Name
            }).ToList();
        public static Mock<IReportsRepository> GetMock()
        {
            var mock = new Mock<IReportsRepository>();
            mock.Setup(m => m.PizzaWithIngredients(It.IsAny<int>()))
                .Returns((int id) => data);
            return mock;
        }
    }
}
