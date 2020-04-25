using System;

namespace Dronai.Packages.Drones.Models
{
    public class Drone
    {
        public int Id { get; set; }

        public string ManufacturerCode { get; set; }

        public DateTime DateOfRegistry { get; set; }

        public int AmountOfDeliveries { get; set; }

        public int BatterySize { get; set; }

        public string Status { get; set; }

        public float Latitude { get; set; }

        public float Longitute { get; set; }
    }
}
