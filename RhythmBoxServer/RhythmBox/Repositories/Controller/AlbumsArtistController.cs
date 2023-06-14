using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using RhythmBox.Data;
using RhythmBox.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using RhythmBox.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Newtonsoft.Json;
using System.Text;

namespace RhythmBox.Repositories.Controller
{
    [Route("api/[controller]")]
    [ApiController, Authorize("Artist")]
    public class AlbumsArtistController : ControllerBase
	{
        private readonly RhythmboxdbContext _context;
        private readonly IAlbumsArtist _albums;
        

        public AlbumsArtistController(RhythmboxdbContext context, IAlbumsArtist albums)
		{
            _context = context;
            _albums = albums;
        }

        [HttpPost("createAlbum")]
        public async Task<IActionResult> createAlbum([FromBody] CreateAlbum model)
        {
            try
            {
                var check = await _albums.postCreateAlbumAsync(_context, model.artistId, model.title, model.releaseDate, model.image);

                if (check.Contains("Error")) return BadRequest(check);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addTrack")]
        public async Task<IActionResult> addTrack([FromBody] CreateTrack model)
        {
            try
            {
                var check = await _albums.postAddTrackToAlbumAsync(_context, model.albumId, model.trackId);

                if (check.Contains("Error")) return BadRequest(check);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteAlbum")]
        public async Task<IActionResult> deleteAlbum(int albumId)
        {
            try
            {
                var check = await _albums.deleteAlbumAsync(_context, albumId);

                if (check.Contains("Error")) return BadRequest(check);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteTrack")]
        public async Task<IActionResult> deleteTrack(int albumId, int trackId)
        {
            try
            {
                var check = await _albums.deleteTrackAsync(_context, albumId, trackId);

                if (check.Contains("Error")) return BadRequest(check);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("updateInformation")]
        public async Task<IActionResult> updateInformation([FromBody] UpdateAlbum model)
        {
            try
            {
                var check = await _albums.putUpdateInformationAsync(_context, model.albumId, model.title, model.releaseDate, model.image);

                if (check.Contains("Error")) return BadRequest(check);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

