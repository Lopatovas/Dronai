using Dronai.Packages.Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dronai.Packages.Orders.Mocks
{
    public class OrderMocks
    {
        public static Order GetOrder()
        {
            Random rand = new Random();
            return new Order
            {
                Id = rand.Next(1000),
                AddressFrom = "Laisves Pr. 469, Kedainiai",
                AddressTo = "Agurku Pl. 15, Kedainiai",
                Status = OrderStatus.PendingPayment.Value,
                DateOfDelivery = new DateTime()
            };
        }

        public static Order[] GetOrders(int count)
        {
            Order[] orders = new Order[count];
            for (int i = 0; i < count; i++)
            {
                orders[i] = GetOrder();
            }

            return orders;
        }
    }
}
