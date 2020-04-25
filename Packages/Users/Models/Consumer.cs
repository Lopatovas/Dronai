using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dronai.Packages.Users.Models
{
    public class Consumer : User
    {
        public ConsumerState State { get; set; }
    }
}
