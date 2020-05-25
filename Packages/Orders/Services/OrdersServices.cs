using Dronai.Packages.Drones.Models;
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
    }
}
