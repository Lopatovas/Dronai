﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dronai.Packages.Drones.Mocks;
using Dronai.Packages.Drones.Models;

namespace Dronai.Packages.Drones.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DronesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDrones()
        {
            return Ok(DroneMocks.GetDrones(20));
        }

        [HttpPost]
        public IActionResult AddDrone(Drone drone)
        {
            Drone newDrone = DroneMocks.GetDrone();
            newDrone.ManufacturerCode = drone.ManufacturerCode;
            newDrone.BatterySize = drone.BatterySize;
            newDrone.AmountOfDeliveries = 0;
            newDrone.DateOfRegistry = new DateTime();
            return Ok(drone);
        }
    }
}
