using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDto
    {
        public OrderDto()
        {

        }

        public int? Id { get; set; }

        public int clientId { get; set; }
        public int? courierId { get; set; }

        public decimal final_price { get; set; }

        public string address_del { get; set; }

        public decimal weight { get; set; }
        public DateTime? ordertime { get; set; }
        public DateTime? deliverytime { get; set; }
        public int delstatusId { get; set; }
        public string DeliveryStatus { get; set; }
        public string? comment { get; set; }

        public List<OrderLineDto> order_lines { get; set; }
        public OrderDto(Order o)
        {
            Id = o.Id;
            clientId = o.ClientId;
            courierId = o.CourierId;
            final_price = o.FinalPrice;
            address_del = o.AddressDel;
            weight = o.Weight;
            ordertime = o.Ordertime;
            deliverytime = o.Deliverytime;
            delstatusId = o.DelstatusId;
            switch (delstatusId)
            {
                case 1:
                    DeliveryStatus = "Не оформлен";
                    break;
                case 2:
                    DeliveryStatus = "Отменен";
                    break;
                case 3:
                    DeliveryStatus = "Формируется";
                    break;
                case 5:
                    DeliveryStatus = "Передан курьеру";
                    break;
                case 6:
                    DeliveryStatus = "Доставлен";
                    break;
                case 7:
                    DeliveryStatus = "Не доставлен";
                    break;
                case 8:
                    DeliveryStatus = "Передается в доставку";
                    break;
            }
            comment = o.Comment;
            order_lines = new List<OrderLineDto>();
            foreach (OrderLine ol in o.OrderLines)
            {
                OrderLineDto olDto = new OrderLineDto(ol);
                order_lines.Add(olDto);
            }
        }
    }
}
