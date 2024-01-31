using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAdo_querries_.Interfaces;
using TestAdo_querries_.Models;

namespace TestAdo_querries_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _users;
        public UsersController(IUsers users) 
        {
            _users=users;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_users.DisplayUsers());
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserDTO user)
        {
            string output = _users.AddUser(user);
            return Ok(output);
        }
    }
}
