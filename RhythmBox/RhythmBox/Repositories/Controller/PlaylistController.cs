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
using System.Text;

namespace RhythmBox.Repositories.Controller
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
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

        [HttpPost("createPlaylist")]
        public async Task<IActionResult> createPlaylist()
        {
            try
            {
                var check = await _playlist.postCreatePlaylistAsync(_context, int.Parse(_user.getUserID()));

                if (check == -1) return BadRequest("Error");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(201);
        }

        [HttpPost("addTrack")]
        public async Task<IActionResult> addTrack([FromBody] PlaylistTrackId model)
        {
            try
            {
                var check = await _playlist.postAddTrackToPlaylistAsync(_context, model.playlistId, model.trackId);

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
        public async Task<IActionResult> addAlbum([FromBody] PlaylistAlbumId model)
        {
            try
            {
                var check = await _playlist.postAddAlbumToPlaylistAsync(_context, model.playlistId, model.albumId);

                if (check == -1) return BadRequest("Error");
                else if (check == 0) return BadRequest("Album or playlist not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(201);
        }

        [HttpGet("getPlaylistLoad")]
        public async Task<IActionResult> getPlaylistLoading()
        {
            try
            {
                var list = await _playlist.getPlaylistsLoadAsync(_context, int.Parse(_user.getUserID()));

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

        [HttpGet("getTracksLoad")]
        public async Task<IActionResult> getTracksLoading(int playlistId)
        {
            try
            {
                var tracks = await _playlist.getTracksLoadingAsync(_context, playlistId);

                if (tracks != null)
                {
                    var response = HttpContext.Response;
                    response.Headers.Add("Content-Type", "application/json");

                    foreach (var track in tracks)
                    {
                        string json = JsonConvert.SerializeObject(track);
                        var bytes = Encoding.UTF8.GetBytes(json);

                        await response.Body.WriteAsync(bytes, 0, bytes.Length);
                        await response.Body.FlushAsync();
                    }

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Content not found");
        }

        [HttpGet("getDuration")]
        public async Task<IActionResult> getDuration(int playlistId)
        {
            (string?, TimeSpan?)? duration;
            try
            {
                duration = await _playlist.getDuration(_context, playlistId);

                if (duration.GetValueOrDefault().Item1 != null || duration.GetValueOrDefault().Item2 == null)
                    return BadRequest(JsonConvert.SerializeObject(duration.GetValueOrDefault().Item1));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonConvert.SerializeObject(duration.GetValueOrDefault().Item2));
        }

        [HttpDelete("deletePlaylist")]
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

        [HttpPost("updateTitle")]
        public async Task<IActionResult> updateTitle([FromBody] PlaylistTitle model)
        {
            try
            {
                var check = await _playlist.postUpdateInformationAsync(_context, model.playlistId, model.newTitle);

                if (check == -1) return BadRequest("Error");
                else if (check == 0) return BadRequest("Playlist not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(201);
        }

        [HttpDelete("deleteTrack")]
        public async Task<IActionResult> deleteTrack(int playlistId, int trackId)
        {
            try
            {
                var check = await _playlist.deleteTrackAsync(_context, playlistId, trackId);

                if (check == -1) return BadRequest("Error");
                else if (check == 0) return BadRequest("Play list or track not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(201);
        }
    }
}

