using Interfaces.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Mocks
{
    public static class MockUoW
    {
        public static Mock<IDbRepos> GetMock()
        {
            var mock = new Mock<IDbRepos>();
            var orderReposMock = MockOrderRepository.GetMock();
            var olineReposMock = MockOrderLineRepository.GetMock();
            var pizzaMock = MockPizzaRepository.GetMock();
            var ingrMock = MockIngredientRepository.GetMock();
            var reportMock = MockReportRepository.GetMock();

            mock.Setup(m => m.Orders).Returns(() => orderReposMock.Object);
            mock.Setup(m => m.OrderLines).Returns(() => olineReposMock.Object);
            mock.Setup(m => m.Pizzas).Returns(() => pizzaMock.Object);
            mock.Setup(m => m.Ingredients).Returns(() => ingrMock.Object);
            mock.Setup(m => m.Reports).Returns(() => reportMock.Object);
            mock.Setup(m => m.Save()).Returns(() => { return 1; });
            return mock;
        }
    }
}
