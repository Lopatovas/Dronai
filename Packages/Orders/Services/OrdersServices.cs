using Dronai.Packages.Drones.Models;
using Dronai.Packages.ForeignKeys;
using Dronai.Packages.Orders.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dronai.Packages.Orders.Services
{
    public class OrdersService
    {

        private MySqlConnection _connection;
        public OrdersService(MySqlConnection conn)
        {
            _connection = conn;
        }

        public List<Order> GetAllOrders()
        {
            List<Order> list = new List<Order>();
            _connection.Open();
            MySqlCommand cmd = new MySqlCommand("select * from Orders", _connection);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Order()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        AddressTo = Convert.ToString(reader["addressTo"]),
                        DateOfDelivery = Convert.ToDateTime(reader["dateOfDelivery"]),
                        Status = Convert.ToString(reader["status"]),
                        AddressFrom = Convert.ToString(reader["addressFrom"]),
                    });
                }
            }
            _connection.Close();
            return list;
        }

        public List<Order> GetUserOrders(int userid)
        {
            _connection.Open();
            var selectQuery = $"select * from userorders where user=\"{userid}\";";
            List<Order> orders = new List<Order>();
            MySqlCommand cmd = new MySqlCommand(selectQuery, _connection);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    UserOrder userOrder = new UserOrder()
                    {
                        User = Convert.ToInt32(reader["user"]),
                        Order = Convert.ToInt32(reader["order"]),
                    };

                    Order order = GetOrder(userOrder.Order);
                    orders.Add(order);

                }
            }
            _connection.Close();
            return orders;
        }

        public Order GetOrder(int id)
        {
            _connection.Open();
            var selectQuery = $"select * from orders where id=\"{id}\";";
            Order order = null;
            MySqlCommand cmd = new MySqlCommand(selectQuery, _connection);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    order = new Order()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        AddressFrom = Convert.ToString(reader["adress"]),
                        AddressTo = Convert.ToString(reader["delivery_adress"]),
                        DateOfDelivery = Convert.ToDateTime(reader["delivery_date"])
                    };
                }
            }
            _connection.Close();
            return order;
        }

        internal Order UpdateOrder(Order order)
        {
            _connection.Open();
            var insertQuerry = $"UPDATE orders SET delivery_date=\"{order.DateOfDelivery}\", adress=\"{order.AddressFrom}\", delivery_adress=\"{order.AddressTo}\", state=\"{order.Status}\";";
            MySqlCommand cmd = new MySqlCommand(insertQuerry, _connection);
            var updated = cmd.ExecuteNonQuery();
            _connection.Close();
            if (updated > 0)
            {
                return order;
            }
            return null;
        }

        public Order AddOrder(Order order)
        {
            _connection.Open();
            var insertQuerry = $"INSERT INTO orders (delivery_date, adress, delivery_adress, state) VALUES(\"{order.DateOfDelivery}\", \"{order.AddressTo}\", \"{order.AddressFrom}\", \"{order.Status}\"); ";
            MySqlCommand cmd = new MySqlCommand(insertQuerry, _connection);
            var updated = cmd.ExecuteNonQuery();
            _connection.Close();
            if (updated > 0)
            {
                return order;
            }
            return null;
        }
    }
}
