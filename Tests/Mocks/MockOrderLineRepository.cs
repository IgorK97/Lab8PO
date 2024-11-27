using DomainModel;
using Interfaces.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Mocks
{
    public static class MockOrderLineRepository
    {
        public static List<OrderLine> lines = new List<OrderLine>()
        {
            new OrderLine()
            {
                Id=1,
                Custom=false,
                OrdersId=1,
                PizzaId=1,
                PizzaSizesId=1,
                PositionPrice=100,
                Weight=100,
                Quantity=1,
                Pizza = MockPizzaRepository.pizzas[0]
            },
            new OrderLine()
            {
                Id=2,
                Custom=false,
                OrdersId=2,
                PizzaId=2,
                PizzaSizesId=1,
                PositionPrice=200,
                Weight=200,
                Quantity=1,
                Pizza = MockPizzaRepository.pizzas[1]
            }

        };
        public static Mock<IRepository<OrderLine>> GetMock()
        {
            var mock = new Mock<IRepository<OrderLine>>();
            var list = lines;
            mock.Setup(m => m.GetList()).Returns(() => list);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => list.FirstOrDefault(ol => ol.Id==id));
            mock.Setup(m => m.Create(It.IsAny<OrderLine>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<OrderLine>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
                .Callback(() => { return; });
            return mock;
        }
    }
}
