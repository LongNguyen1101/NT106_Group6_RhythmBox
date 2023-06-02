using System;
using Microsoft.AspNetCore.Mvc;
using RhythmBox.Data;
using RhythmBox.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace RhythmBox.Repositories
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbUsersController : ControllerBase
	{
        private readonly RhythmboxdbContext _context;
        private readonly IDbUsers _dbUsers;

        public DbUsersController(RhythmboxdbContext context, IDbUsers dbUsers)
		{
            _context = context;
            _dbUsers = dbUsers;
		}

        [HttpPost("CreateUser")]
        public async Task<IActionResult> createUser(string userName, string email, string password, string birthday, string gender)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(gender))
            {
                try
                {
                    int check = await _dbUsers.postCreateUserAsync(_context, userName, email.ToLower(), password, birthday, gender);

                    if (check == 0) return NotFound("User is alreary exist");
                    else if (check == -1) return BadRequest("Error");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }

            return StatusCode(201);
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> getUser(string authenticString, string password)
        {
            if (!string.IsNullOrEmpty(authenticString) && !string.IsNullOrEmpty(password))
            {
                try
                {
                    var userInfo = await _dbUsers.getUserAsync(_context, authenticString, password);

                    return Ok(userInfo.Item1);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return BadRequest();
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> changePassword(int userId, string oldPassword, string newPassword)
        {
            if (!string.IsNullOrEmpty(oldPassword) && !string.IsNullOrEmpty(newPassword))
            {
                try
                {
                    int check = await _dbUsers.postChangePasswordAsync(_context, userId, oldPassword, newPassword);

                    if (check == 0) return BadRequest("Wrong id or password");
                    else if (check == -1) return BadRequest("Error");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return StatusCode(201);
        }
	}
}

