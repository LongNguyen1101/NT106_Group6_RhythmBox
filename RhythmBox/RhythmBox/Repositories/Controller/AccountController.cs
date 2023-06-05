using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RhythmBox.Repositories.Interface;
using RhythmBox.Data;
using RhythmBox.Models;
using System.Data;

namespace RhythmBox.Repositories.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly RhythmboxdbContext _dbContext;
        private readonly IAccount _account;
        private readonly IConfiguration _configuration;
        private readonly IDbUsers dbUsers;

        public AccountController(RhythmboxdbContext dbContext, IAccount account, IConfiguration configuration, IDbUsers dbUsers)
        {
            _dbContext = dbContext;
            _account = account;
            _configuration = configuration;

            this.dbUsers = dbUsers;
        }
        [HttpPost("register")]
        public ActionResult<User> Register(string userName, string email, string password, string birthday, string gender)
        { 
            var newUser = _account.Register(_dbContext, userName, email, password, birthday, gender);
            if (newUser == null)
            {
                return BadRequest("Tài khoản đã tồn tại");
            }
            return Ok(newUser);
        }
        [HttpPost("login")]
        public ActionResult Login(string email, string password)
        {
            var result = _account.Login(_dbContext, _configuration, email, password);
            if (result == "User not found") 
            {
                return BadRequest(result);
            }
            if (result == "Wrong password")
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
