using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dronai.Packages.Drones.Mocks;
using Dronai.Packages.Drones.Models;
using Dronai.Packages.Drones.Services;
using Microsoft.AspNetCore.Http;

namespace Dronai.Packages.Drones.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DronesController : ControllerBase
    {
        private DronesDbContext _context;
        private DronesService _service;

        public DronesController(IHttpContextAccessor httpContextAccessor)
        {
            _context = httpContextAccessor.HttpContext.RequestServices.GetService(typeof(DronesDbContext)) as DronesDbContext;
            _service = new DronesService(_context.GetConnection());
        }

        [HttpGet]
        public IActionResult GetDrones()
        {
            var drones = _service.GetAllDrones();
            return Ok(drones);
        }

        [HttpPost]
        public IActionResult AddDrone(Drone drone)
        {
            drone.AmountOfDeliveries = 0;
            drone.DateOfRegistry = DateTime.Now.Date;
            drone.Latitude = 0f;
            drone.Longitute = 0f;
            drone.Status = DroneStatus.Free.Value;
            var newDrone = _service.AddDrone(drone);
            return Ok(newDrone);
        }
    }
}
