using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dronai.Packages.Users.Models
{
    public class Employee : User
    {
        public string PersonalId { get; set; }

        public string Position { get; set; }

        public string HomeAddress { get; set; }
    }
}
