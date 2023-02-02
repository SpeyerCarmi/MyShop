using AutoMapper;
using DTO;
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
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, IMapper mapper, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
            _mapper = mapper;

        }


        // GET: api/<UserController>
        [HttpGet]

        public async Task<ActionResult<IEnumerable<UserWithPasswordDTO>>> GetUsers([FromQuery] string Name, [FromQuery] string password)
        {
            _logger.LogInformation("Login attempted with User Name , {0} and password {1}", Name, password);

            User user = await _userService.getUsers(Name, password);
            if (user == null)
                return NoContent();
            UserWithPasswordDTO userDTO = _mapper.Map<User, UserWithPasswordDTO>(user);
            return Ok(userDTO);
        }

        // POST api/<UserController>
        [HttpPost]
        public  async Task<ActionResult<UserWithPasswordDTO>> insertUser([FromBody] UserWithPasswordDTO userDTO)
        {

            User user = _mapper.Map<UserWithPasswordDTO, User>(userDTO);

            User newUser = await _userService.insertUser(user);
            UserWithPasswordDTO newUserDTO = _mapper.Map<User, UserWithPasswordDTO>(newUser);

            return CreatedAtAction(nameof(GetUsers), new {id = user.Id }, newUserDTO);
            

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void updateUser( int id, [FromBody] User user)
        {
            _userService.updateUser(id,user);
        }

    }

}
