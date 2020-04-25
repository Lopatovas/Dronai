using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dronai.Packages.Users.Models
{
    public class ConsumerState
    {
        private ConsumerState(string value) { Value = value; }

        public string Value { get; set; }

        public static ConsumerState Suspended { get { return new ConsumerState("Suspenduotas"); } }
        public static ConsumerState Active { get { return new ConsumerState("Aktyvus"); } }
    }
}
