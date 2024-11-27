using DomainModel;
using Interfaces.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static BLL.Services.OrderService;

namespace Tests.Mocks
{
    public class MockOrderRepository
    {
        public static List<Order> orders = new List<Order>()
            {
            new Order()
            {
                Id=1,
                ClientId=1,
                CourierId=null,
                ManagersId=null,
                AddressDel="",
                Comment="",
                Deliverytime=null,
                Ordertime=null,
                DelstatusId=(int)DeliveryStatus.NotPlaced,
                FinalPrice=100,
                Weight=100,
                OrderLines = new List<OrderLine>(){MockOrderLineRepository.lines[0] }
            },
            new Order()
            {
                Id=2,
                ClientId=1,
                CourierId=null,
                ManagersId=null,
                AddressDel="",
                Comment="",
                Deliverytime=null,
                Ordertime=null,
                DelstatusId=(int)DeliveryStatus.NotPlaced,
                FinalPrice=200,
                Weight=200,
                OrderLines = new List<OrderLine>(){MockOrderLineRepository.lines[1] }
            },
            new Order()
            {
                Id=3,
                ClientId=1,
                FinalPrice=0.00M,
                DelstatusId=(int)DeliveryStatus.NotPlaced,
                Weight=0
            },
            new Order()
            {
                Id=4,
                ClientId=1,
                FinalPrice=100,
                Weight=100,
                CourierId=null,
                ManagersId=null,
                AddressDel="",
                Comment="",
                Deliverytime=null,
                Ordertime=null,
                DelstatusId=(int)DeliveryStatus.NotPlaced,
                OrderLines = new List<OrderLine>(){MockOrderLineRepository.lines[2] }

            },
            new Order()
            {
                Id=5,
                ClientId=1,
                CourierId=null,
                ManagersId=null,
                AddressDel="",
                Comment="",
                Deliverytime=null,
                Ordertime=null,
                DelstatusId=(int)DeliveryStatus.IsBeingFormed,
                FinalPrice=100,
                Weight=100,
                OrderLines = new List<OrderLine>(){MockOrderLineRepository.lines[3] }
            }
        };
        public static Mock<IRepository<Order>> GetMock()
        {
            var mock = new Mock<IRepository<Order>>();
            var list = orders;
            mock.Setup(m => m.GetList()).Returns(() => list);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => list.FirstOrDefault(ol => ol.Id == id));
            mock.Setup(m => m.Create(It.IsAny<Order>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<Order>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
                .Callback(() => { return; });
            return mock;
        }
    }
}
