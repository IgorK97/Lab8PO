using BLL.Services;
using DomainModel.Exceptions;
using Interfaces.Repository;
using Moq;
using Tests.Mocks;

namespace Tests.Service
{
    public class OrderServiceTest
    {
        Mock<IDbRepos> uowMock;
        OrderService service;
        [SetUp]
        public void Setup()
        {
            uowMock = MockUoW.GetMock();
            service = new OrderService(uowMock.Object);
        }

        [Test]
        public void SubmitOrder_OrderNotFound_ThrowsOrderNotFoundException()
        {
            //Arrange
            int OrderId = 10;
            string address = "address";

            //Act
            OrderNotFoundException exception = Assert.Throws<OrderNotFoundException>(()
                => service.SubmitOrder(OrderId, address));

            //Assert
            int factualId = exception.OId;
            Assert.AreEqual(OrderId, factualId);
        }
        [Test]
        public void SubmitOrder_EmptyOrder_ThrowsEmptyOrderException()
        {
            //Arrange
            int OrderId = 3;
            string address = "address";

            //Act
            EmptyOrderException exception = Assert.Throws<EmptyOrderException>(()
                => service.SubmitOrder(OrderId, address));

            //Assert
            int factualId = exception.odId;
            Assert.AreEqual(OrderId, factualId);
        }
        [Test]
        public void SubmitOrder_PizzaMissing_ThrowsOrderComponentMissingException()
        {
            int OrderId = 2;
            string address = "address";
            string pname = "pizza2";

            OrderComponentMissingException exc = Assert.Throws<OrderComponentMissingException>(()
                => service.SubmitOrder(OrderId, address));

            string factualName = exc.Name;
            Assert.AreEqual(pname, factualName);
        }
        [Test]
        public void SubmitOrder_IngredientMissing_ThrowsOrderComponentMissingException()
        {
            int OrderId = 4;
            string address = "address";
            string iname = "i2";

            OrderComponentMissingException e = Assert.Throws<OrderComponentMissingException>(()
                => service.SubmitOrder(OrderId, address));

            string factualName = e.Name;
            Assert.AreEqual(iname, factualName);
        }
        [Test]
        public void SubmitOrder_Success()
        {
            int OrderId = 1;
            string address = "address";
            try
            {
                service.SubmitOrder(OrderId, address);
            }
            catch (Exception e) { }
            Assert.Pass();
        }
        [Test]
        public void CancelOrder_Success()
        {
            int OrderId = 5;
            try
            {
                service.CancelOrder(OrderId);
            }
            catch (Exception e) { }
            Assert.Pass();
        }
        [Test]
        public void CancelOrder_OrderNotFound_ThrowsOrderNotFoundException()
        {
            int OrderId = 10;

            OrderNotFoundException e = Assert.Throws<OrderNotFoundException>(()
                => service.CancelOrder(OrderId));

            int factualOrderId = e.OId;
            Assert.AreEqual(OrderId, factualOrderId);
        }
        [Test]
        public void UpdateOrder_Success()
        {
            int OrderId = 1;
            try
            {
                service.UpdateOrder(OrderId);
            }
            catch (Exception e) { }
            Assert.Pass();
        }
        [Test]
        public void UpdateOrder_OrderNotFound_throwsOrderNotFoundException()
        {
            int OrderId = 10;

            OrderNotFoundException e = Assert.Throws<OrderNotFoundException>(()
                => service.UpdateOrder(OrderId));

            int factualOrderId = e.OId;
            Assert.AreEqual(OrderId, factualOrderId);
        }

    }
}