using System;

namespace Dronai.Packages.Orders.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string AddressTo { get; set; }

        public DateTime DateOfDelivery { get; set; }

        public OrderStatus Status { get; set; }

        public string AddressFrom { get; set; }
    }
}
