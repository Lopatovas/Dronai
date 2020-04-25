namespace Dronai.Packages.Drones.Models
{
    public class DroneStatus
    {
        private DroneStatus(string value) { Value = value; }

        public string Value { get; set; }

        public static DroneStatus Taken { get { return new DroneStatus("Užimtas"); } }
        public static DroneStatus Free { get { return new DroneStatus("Laisvas"); } }
        public static DroneStatus Charging { get { return new DroneStatus("Kraunasi"); } }
        public static DroneStatus BeingFixed { get { return new DroneStatus("Tvarkomas"); } }
        public static DroneStatus Broken { get { return new DroneStatus("Sugedęs"); } }
        public static DroneStatus PerformingOrder { get { return new DroneStatus("Pristatinėja prekias"); } }
    }
}
