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
        public IActionResult LoginUser([FromBody] string userName, string password)
        {
            System.Console.WriteLine(password);
            return Ok(userName);
        }
    }
}
