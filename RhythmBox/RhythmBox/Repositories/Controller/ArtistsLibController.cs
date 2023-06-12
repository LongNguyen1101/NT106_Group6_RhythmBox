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
using RhythmBox.Repositories.Services;
using Newtonsoft.Json;

namespace RhythmBox.Repositories.Controller
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class ArtistsLibController : ControllerBase
    {
        private readonly RhythmboxdbContext _context;
        private readonly IArtistsLib _artistsLib;
        private readonly IUserService _userService;

        public ArtistsLibController(RhythmboxdbContext context, IArtistsLib artistsLib, IUserService userService)
		{
            _context = context;
            _artistsLib = artistsLib;
            _userService = userService;
        }

        [HttpDelete("deleteArtist")]
        public async Task<IActionResult> deleteAlbumsLib([FromBody] int artistsLibId)
        {
            try
            {
                int check = await _artistsLib.deleteArtistsLibAsync(_context, artistsLibId);

                if (check == -1) return BadRequest("Error");
                else if (check == 0) return BadRequest("Album not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(201);
        }

        [HttpGet("getArtistLoad")]
        public async Task<IActionResult> getArtistLoading()
        {
            try
            {
                var list = await _artistsLib.getArtistsLibraryAsync(_context, int.Parse(_userService.getUserID()));

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

        [HttpPost("addArtist")]
        public async Task<IActionResult> postAddAlbumtoLib([FromBody] int artistId)
        {
            try
            {
                var check = await _artistsLib.postAddArtistToLibAsync(_context, int.Parse(_userService.getUserID()), artistId);

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

