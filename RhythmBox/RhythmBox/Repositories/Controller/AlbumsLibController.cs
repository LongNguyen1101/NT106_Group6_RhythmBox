using System;
using Microsoft.AspNetCore.Mvc;
using RhythmBox.Data;
using RhythmBox.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using RhythmBox.Repositories.Interface;

namespace RhythmBox.Repositories.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsLibController : ControllerBase
    {
        private readonly RhythmboxdbContext _context;
        private readonly IAlbumsLib _albumsLib;

        public AlbumsLibController(RhythmboxdbContext context, IAlbumsLib albumsLib)
		{
            _context = context;
            _albumsLib = albumsLib;
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
        public async Task<IActionResult> getAlbumLoading(int userId)
        {
            try
            {
                var list = await _albumsLib.getAlbumsLibraryAsync(_context, userId);

                if (list != null)
                {
                    List<string> title = list.Where(con => con.Item2 != null)
                                            .Select(con => con.Item2)
                                            .ToList();

                    return Ok(title);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest("Error");
        }

        [HttpPost("addAlbum")]
        public async Task<IActionResult> postAddAlbumtoLib(int userId, int albumId)
        {
            try
            {
                var check = await _albumsLib.postAddAlbumToLibAsync(_context, userId, albumId);

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

