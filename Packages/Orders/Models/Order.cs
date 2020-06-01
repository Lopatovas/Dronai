using System;

namespace Dronai.Packages.Orders.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string AddressTo { get; set; }

        public string DateOfDelivery { get; set; }

        public string Status { get; set; }

        public string AddressFrom { get; set; }

        public int userId { get; set; }
    }
}
