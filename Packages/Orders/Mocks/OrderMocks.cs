using Dronai.Packages.Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dronai.Packages.Orders.Mocks
{
    public class OrderMocks
    {
        private static string RandomizeStatus()
        {
            Random rand = new Random();
            int randomValue = rand.Next(5);
            switch (randomValue)
            {
                case 0:
                    return OrderStatus.Paid.Value;
                case 1:
                    return OrderStatus.Confirmed.Value;
                case 2:
                    return OrderStatus.Denied.Value;
                case 3:
                    return OrderStatus.PendingPayment.Value;
                case 4:
                    return OrderStatus.Delivered.Value;
                default:
                    return OrderStatus.Ordered.Value;
            }
                
        }

        public static Order GetOrder()
        {
            Random rand = new Random();
            return new Order
            {
                Id = rand.Next(1000),
                AddressFrom = "Laisves Pr. 469, Kedainiai",
                AddressTo = "Agurku Pl. 15, Kedainiai",
                Status = RandomizeStatus(),
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
