namespace Dronai.Packages.Orders.Models
{
    public class OrderStatus
    {
        private OrderStatus(string value) { Value = value; }

        public string Value { get; set; }

        public static OrderStatus Ordered { get { return new OrderStatus("Užsakyta"); } }
        public static OrderStatus Confirmed { get { return new OrderStatus("Patvirtinta"); } }
        public static OrderStatus Denied { get { return new OrderStatus("Atmesta"); } }
        public static OrderStatus Delivered { get { return new OrderStatus("Pristatyta"); } }
        public static OrderStatus PendingPayment { get { return new OrderStatus("Laukia apmokėjimo"); } }
        public static OrderStatus Paid { get { return new OrderStatus("Apmokėta"); } }
    }
}
