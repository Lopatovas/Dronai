using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dronai.Packages.Users.Models
{
    public class EmployeePosition
    {
        private EmployeePosition(string value) { Value = value; }

        public string Value { get; set; }

        public static EmployeePosition Loader { get { return new EmployeePosition("Krovėjas"); } }
        public static EmployeePosition Administrator { get { return new EmployeePosition("Administratorius"); } }

        public static EmployeePosition DroneSupervisor { get { return new EmployeePosition("Dronų prižiūrėtojas"); } }
    }
}
