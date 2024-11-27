using BLL.Services;
using Interfaces.Repository;
using Moq;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Mocks;

namespace Tests.Service
{
    public class ReportServiceTest
    {
        Mock<IDbRepos> uowMock;
        ReportService service;
        [SetUp]
        public void Setup()
        {
            uowMock = MockUoW.GetMock();
            service = new ReportService(uowMock.Object);
        }
        [Test]
        public void Report_Succecc_2()
        {
            int IngrId = 1;
            var result = service.ReportPizzas(IngrId);
            Assert.IsNotNull(result);
            Assert.That(MockPizzaRepository.pizzas.Count, Is.EqualTo(result.Count));
            Assert.Pass();
        }
        [Test]
        public void Report_Succecc_Null()
        {
            int IngrId = 2;
            var result = service.ReportPizzas(IngrId);
            Assert.AreEqual(0,result.Count);
        }
    }
}
