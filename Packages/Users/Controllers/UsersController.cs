using Dronai.Packages.Users.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dronai.Packages.Users.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public IActionResult RegisterUser(User user)
        {
            return Ok(user);
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult LoginUser([FromBody] User payload)
        {
            System.Console.WriteLine(payload.Password);
            return Ok(payload.Email);
        }
    }
}
