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
        public async Task<IActionResult> Create(string userName, string email, string password, string birthday, string gender)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(gender))
            {
                try
                {
                    int check = await _dbUsers.postCreateUserAsync(_context, userName, email.ToLower(), password, birthday, gender);

                    if (check == 0) return NotFound("User is alreary exist");
                    else if (check == -1) return NotFound("Error adding new user");
                }
                catch
                {
                    return BadRequest();
                }
                
            }

            return Ok();
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> getUser(string authenticString, string password)
        {
            if (!string.IsNullOrEmpty(authenticString) && !string.IsNullOrEmpty(password))
            {
                try
                {
                    await _dbUsers.getUserAsync(_context, authenticString, password);
                }
                catch
                {
                    return BadRequest();
                }
            }

            return Ok();
        }
	}
}

