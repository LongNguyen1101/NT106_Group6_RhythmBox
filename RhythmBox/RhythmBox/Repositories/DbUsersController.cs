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

        [HttpPost("UploadNewUser")]
        public async Task<IActionResult> NewUserUpload(string userName, string email, string password, string birthday, string gender)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(gender))
            {
                try
                {
                    await _dbUsers.newUserUploadAsync(_context, userName, email, password, birthday, gender);
                }
                catch
                {
                    return BadRequest();
                }
                
            }

            return Ok();
        }

        [HttpGet("DownloadUser")]
        public async Task<IActionResult> UserDownload(string userName, string email)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(email))
            {
                try
                {
                    await _dbUsers.userDownloadAsync(_context, userName, email);
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

