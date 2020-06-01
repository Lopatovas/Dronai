using Dronai.Packages.Drones.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dronai.Packages.Drones.Services
{
    public class DronesService
    {

        private MySqlConnection _connection;
        public DronesService(MySqlConnection conn)
        {
            _connection = conn;
        }

        public List<Drone> GetAllDrones()
        {
            List<Drone> list = new List<Drone>();
            _connection.Open();
            MySqlCommand cmd = new MySqlCommand("select * from drones", _connection);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Drone()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        ManufacturerCode = Convert.ToString(reader["manufacturerCode"]),
                        DateOfRegistry = Convert.ToDateTime(reader["dateOfRegistry"]),
                        AmountOfDeliveries = Convert.ToInt32(reader["amountOfDeliveries"]),
                        BatterySize = Convert.ToInt32(reader["batterySize"]),
                        Status = Convert.ToString(reader["status"]),
                        Latitude = Convert.ToInt64(reader["latitude"]),
                        Longitute = Convert.ToInt64(reader["longitute"]),
                    });
                }
            }
            _connection.Close();
            return list;
        }

        public Drone AddDrone(Drone drone)
        {
            _connection.Open();
            var insertQuerry = $"INSERT INTO drones (manufacturerCode, dateOfRegistry, amountOfDeliveries, batterySize, status, latitude, longitute) VALUES(\"{drone.ManufacturerCode}\", \"{drone.DateOfRegistry}\", {drone.AmountOfDeliveries}, {drone.BatterySize}, \"{drone.Status}\", {drone.Latitude}, {drone.Longitute}); ";
            MySqlCommand cmd = new MySqlCommand(insertQuerry, _connection);
            var updated = cmd.ExecuteNonQuery();
            _connection.Close();
            if (updated > 0)
            {
                return drone;
            }
            return null;
        }
    }
}
