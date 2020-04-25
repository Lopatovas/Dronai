using Dronai.Packages.Drones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dronai.Packages.Drones.Mocks
{
    public static class DroneMocks
    {
        public static Drone GetDrone()
        {
            Random rand = new Random();
            return new Drone {
                AmountOfDeliveries = rand.Next(50),
                BatterySize = rand.Next(150),
                DateOfRegistry = new DateTime(1999, 1, 1),
                ManufacturerCode = "123456",
                Status = DroneStatus.Free.Value,
                Latitude = 102315.15f,
                Longitute = 12452.20f,
                Id = rand.Next(1000)
            };
        }

        public static Drone[] GetDrones(int count)
        {
            Drone[] drones = new Drone[count];
            for (int i = 0; i < count; i++)
            {
                drones[i] = GetDrone();
            }

            return drones;
        }
    }
}
