using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RhythmBox.Repositories.Interface;
using RhythmBox.Data;
using RhythmBox.Models;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using RhythmBox.Models.DTO;

namespace RhythmBox.Repositories.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly RhythmboxdbContext _dbContext;
        private readonly IAccount _account;
        private readonly IConfiguration _configuration;

        public AccountController(RhythmboxdbContext dbContext, IAccount account, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _account = account;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public ActionResult<User> Register([FromBody] Register user)
        { 
            var newUser = _account.Register(_dbContext, user.userName!, user.email!, user.password!, user.birthday.ToString()!, user.gender!);
            if (newUser == null)
            {
                return BadRequest("Tài khoản đã tồn tại");
            }
            return Ok(newUser);
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] Login model)
        {
            var result = _account.Login(_dbContext, _configuration, model.email!, model.password!);

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

        [HttpPut("updateAccount"), Authorize("User")]
        public ActionResult UpdateAccount([FromBody] ArtistInfo artistInfo)
        {
            bool isUpdated = _account.updateUser(_dbContext, artistInfo);
            return isUpdated ? Ok() : BadRequest();
        }
    }
}
