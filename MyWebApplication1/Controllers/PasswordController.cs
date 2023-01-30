using Microsoft.AspNetCore.Mvc;
using Service;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {

        private readonly IPasswordSrv _passwordSrv;

        public PasswordController(IPasswordSrv passwordSrv)
        {
            _passwordSrv = passwordSrv;
        }


        // POST api/<PasswordController>
        [HttpPost]
        public Result checkPassword([FromBody] string password)
        {
            return _passwordSrv.checkPassword(password);
        }

    }
}
