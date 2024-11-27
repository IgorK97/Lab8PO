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
    public static class MockPizzaRepository
    {
        public static List<Pizza> pizzas = new List<Pizza>()
        {
            new Pizza()
            {
                Id=1,
                Active=true,
                Description="",
                Name="pizza1"
            },
            new Pizza()
            {
                Id=2,
                Active=true,
                Description="",
                Name="pizza2"
            }
        };
        public static Mock<IRepository<Pizza>> GetMock()
        {
            var mock = new Mock<IRepository<Pizza>>();
            var list = pizzas;
            mock.Setup(m => m.GetList()).Returns(() => list);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => list.First());
            mock.Setup(m => m.Create(It.IsAny<Pizza>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<Pizza>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
                .Callback(() => { return; });
            return mock;
        }
    }
}
