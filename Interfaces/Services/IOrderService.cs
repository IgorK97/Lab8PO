using DomainModel;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IOrderService
    {
        int GetCurrentOrder(int ClientId);

        OrderDto RetOrder(int cur);

        bool MakeOrder(int ClientId);


        bool CancelOrder(int odId);

        void SubmitOrder(int odId, string addressdel);

        (decimal price, decimal weight) UpdateOrder(int odId);


        List<OrderDto> GetAllOrders(int ClientId);

        
    }
}
