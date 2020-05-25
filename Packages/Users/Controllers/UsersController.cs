using Dronai.Packages.Users.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dronai.Packages.Users.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dronai.Packages.Users.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private DronesDbContext _context;
        private UsersServices _service;

        public UsersController(IHttpContextAccessor httpContextAccessor)
        {
            _context = httpContextAccessor.HttpContext.RequestServices.GetService(typeof(DronesDbContext)) as DronesDbContext;
            _service = new UsersServices(_context.GetConnection());
        }
        [HttpPost]
        public IActionResult RegisterUser(User user)
        {
            var newUser = _service.RegisterUser(user);
            return Ok(newUser);
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult LoginUser([FromBody] User payload)
        {
            var response = _service.AuthenticateUser(payload);
            if (response != null)
            {
                return Ok(response.Email);
            }
            return NotFound();
        }
    }
}
