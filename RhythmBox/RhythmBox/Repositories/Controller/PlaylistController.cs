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
using Microsoft.AspNetCore.Mvc.Authorization;
using Newtonsoft.Json;

namespace RhythmBox.Repositories.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
	{
        private readonly RhythmboxdbContext _context;
        private readonly IPlaylist _playlist;
        private readonly IUserService _user;

        public PlaylistController(RhythmboxdbContext context, IPlaylist playlist, IUserService user)
		{
            _context = context;
            _playlist = playlist;
            _user = user;
		}

        // check for id
        [HttpPost("createPlaylist")]
        public async Task<IActionResult> createPlaylist(int id)
        {
            try
            {
                //var check = await _playlist.postCreatePlaylistAsync(_context, int.Parse(_user.getUserID()));
                var check = await _playlist.postCreatePlaylistAsync(_context, id);

                if (check == -1) return BadRequest("Error");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(201);
        }

        [HttpPost("addTrack")]
        public async Task<IActionResult> addTrack(int playlistId, int trackId)
        {
            try
            {
                var check = await _playlist.postAddTrackToPlaylistAsync(_context, playlistId, trackId);

                if (check == -1) return BadRequest("Error");
                else if (check == 0) return BadRequest("Playlist or track not found");
                else if (check == -2) return BadRequest("Track already exist");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(201);
        }

        [HttpPost("addAlbum")]
        public async Task<IActionResult> addAlbum(int playlistId, int albumId)
        {
            try
            {
                var check = await _playlist.postAddAlbumToPlaylistAsync(_context, playlistId, albumId);

                if (check == -1) return BadRequest("Error");
                else if (check == 0) return BadRequest("Album or playlist not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(201);
        }

        // check for id
        [HttpGet("getPlaylistLoad")]
        public async Task<IActionResult> getPlaylistLoading(int id)
        {
            try
            {
                var list = await _playlist.getPlaylistsLoadAsync(_context, id);

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

        [HttpPost("deletePlaylist")]
        public async Task<IActionResult> deletePlaylist(int playlistId)
        {
            try
            {
                var check = await _playlist.deletePlaylistAsync(_context, playlistId);

                if (check == -1) return BadRequest("Error");
                else if (check == 0) return BadRequest("playlist not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(201);
        }

        [HttpGet("downloadPlaylist")]
        public async Task<IActionResult> downloadPlaylist(int playlistId)
        {
            try
            {
                var lists = await _playlist.getDownloadPlaylistAsync(_context, playlistId);

                if (lists != null)
                {
                    foreach (var list in lists)
                    {
                        string json = await Task.Run(() => JsonConvert.SerializeObject(list));

                        return Ok(json);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest("Error");
        }
    }
}

