using System;
using Microsoft.AspNetCore.Mvc;
using RhythmBox.Data;
using RhythmBox.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using RhythmBox.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace RhythmBox.Repositories.Controller
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class AlbumsLibController : ControllerBase
    {
        private readonly RhythmboxdbContext _context;
        private readonly IAlbumsLib _albumsLib;
        private readonly IUserService _userService;

        public AlbumsLibController(RhythmboxdbContext context, IAlbumsLib albumsLib, IUserService userService)
		{
            _context = context;
            _albumsLib = albumsLib;
            _userService = userService;
		}

        [HttpDelete("deleteAlbumLib")]
        public async Task<IActionResult> deleteAlbumsLib(int albumsLibId)
        {
            try
            {
                int check = await _albumsLib.deleteAlbumLibAsync(_context, albumsLibId);

                if (check == -1) return BadRequest("Error");
                else if (check == 0) return BadRequest("Album not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(201);
        }

        [HttpGet("getAlbumLoad")]
        public async Task<IActionResult> getAlbumLoading()
        {
            try
            {
                var list = await _albumsLib.getAlbumsLibraryAsync(_context, int.Parse(_userService.getUserID()));

                if (list != null)
                {
                    string json = JsonConvert.SerializeObject(list);

                    return Ok(json);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest("Error");
        }

        [HttpPost("addAlbum")]
        public async Task<IActionResult> postAddAlbumtoLib([FromBody] int albumId)
        {
            try
            {
                var check = await _albumsLib.postAddAlbumToLibAsync(_context, int.Parse(_userService.getUserID()), albumId);

                if (check == -1) return BadRequest("Error");
                else if (check == 0) return BadRequest("album aready exist");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(201);
        }
	}
}

