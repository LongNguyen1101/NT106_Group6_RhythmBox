using System;
using Microsoft.AspNetCore.Mvc;
using RhythmBox.Data;
using RhythmBox.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using RhythmBox.Repositories.Interface;

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

        [HttpPost("createUser")]
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

        [HttpGet("getUser")]
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

        [HttpPost("changePassword")]
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

        [HttpGet("getInfoOtherUser")]
        public async Task<IActionResult> getInfo(int userId)
        {
            if (userId != 0)
            {
                try
                {
                    var user = await _dbUsers.getInfoOtherUserAsync(_context, userId);

                    if (user.Item1 != null)
                    {
                        if (user.Item2 != null)
                            return Ok(user);

                        return Ok(user.Item1);
                    }
                    else return BadRequest("User not found");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return BadRequest("Error");
        }

        [HttpPost("changeInfo")]
        public async Task<IActionResult> changeInfo(int userId, string newUserName, string newEmail, [FromForm] FileDetails newAva, string newBirthday, string newGender)
        {
            if (userId != 0)
            {
                try
                {
                    FileContent fileContent = new FileContent();

                    fileContent.fileName = newAva.fileDetail.FileName;

                    using (MemoryStream stream = new MemoryStream())
                    {
                        await newAva.fileDetail.CopyToAsync(stream);
                        fileContent.content = stream.ToArray();
                    }

                    int check = await _dbUsers.postChangeInformationAsync(_context, userId, newUserName, newEmail, fileContent, newBirthday, newGender);

                    if (check == 0) return BadRequest("Error");
                    else if (check == -1) return BadRequest("User not found");
                    else return StatusCode(201);
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return BadRequest("User not found");
        }

        //[HttpGet("getPlaylist")]
        //public async Task<IActionResult> getPlaylist(int userId)
        //{
        //    if (userId != 0)
        //    {
        //        try
        //        {
        //            var playlist = await _dbUsers.getPlaylistAsync(_context, userId);

        //            return Ok(playlist);
        //        }
        //        catch (Exception ex)
        //        {
        //            return BadRequest(ex.Message);
        //        }
        //    }

        //    return BadRequest("User not found");
        //}

        //[HttpGet("getAlbumsLib")]
        //public async Task<IActionResult> getAlbumsLib(int userId)
        //{
        //    if (userId != 0)
        //    {
        //        try
        //        {
        //            var albumsLib = await _dbUsers.getAlbumsLibraryAsync(_context, userId);

        //            return Ok(albumsLib);
        //        }
        //        catch (Exception ex)
        //        {
        //            return BadRequest(ex.Message);
        //        }
        //    }

        //    return BadRequest("User not found");
        //}

        //[HttpGet("getArtistsLib")]
        //public async Task<IActionResult> getArtistsLib(int userId)
        //{
        //    if (userId != 0)
        //    {
        //        try
        //        {
        //            var artistsLib = await _dbUsers.getArtistsLibraryAsync(_context, userId);

        //            return Ok(artistsLib);
        //        }
        //        catch (Exception ex)
        //        {
        //            return BadRequest(ex.Message);
        //        }
        //    }

        //    return BadRequest("User not found");
        //}

        //[HttpGet("getTracks")]
        //public async Task<IActionResult> getTracks()
        //{
        //    try
        //    {
        //        var tracks = await _dbUsers.getTracksAsync(_context);

        //        if (tracks != null)
        //        {
        //            return Ok(tracks.ToString());
        //        }

        //        else return BadRequest("Error for getting tracks");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpDelete("deleteUser")]
        public async Task<IActionResult> deleteUser(int userId)
        {
            try
            {
                int check = await _dbUsers.deleteUserAsync(_context, userId);

                if (check == 1) return StatusCode(201);
                else if (check == 0) return BadRequest("User not found");
                else return BadRequest("Something error");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("findUser")]
        public async Task<IActionResult> findUser(string searchString)
        {
            try
            {
                var users = await _dbUsers.getFindUserAsync(_context, searchString);

                if (users != null) return Ok(users.ToString());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getAllUsers")]
        public async Task<IActionResult> getAllUsers()
        {
            try
            {
                var users = await _dbUsers.getAllusers(_context);

                if (users != null) return Ok(users);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

