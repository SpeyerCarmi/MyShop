using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
       

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        // GET: api/<UserController>
        [HttpGet]

        public async Task<ActionResult<IEnumerable<User>>> GetUsers([FromQuery] string Name, [FromQuery] string password)
        {
            User user = await _userService.getUsers(Name, password);
            return user == null ? NotFound() : Ok(user);
        }


        // GET api/<UserController>/5
        [HttpGet("{id}")]

        public string Get(int id)
        {
            return "value";
        }
        // POST api/<UserController>
        [HttpPost]
        public  async Task<ActionResult<User>> insertUser([FromBody] User user)
        {
            User Suser = await _userService.insertUser(user);
            if (Suser == null)
                return NotFound();
            return CreatedAtAction(nameof(Get), new {id = user.Id }, user);
            

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void updateUser( int id, [FromBody] User user)
        {
            _userService.updateUser(id,user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

}
