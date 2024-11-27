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
    public static class MockIngredientRepository
    {
        public static List<Ingredient> ingrs = new List<Ingredient>()
        {
            new Ingredient()
            {
                Id=1,
                Name="i1"
            },
            new Ingredient()
            {
                Id=2,
                Name="i2"
            }
        };
        public static Mock<IRepository<Ingredient>> GetMock()
        {
            var mock = new Mock<IRepository<Ingredient>>();
            var list = ingrs;
            mock.Setup(m => m.GetList()).Returns(() => list);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => list.First());
            mock.Setup(m => m.Create(It.IsAny<Ingredient>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<Ingredient>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
                .Callback(() => { return; });
            return mock;
        }
    }
}
