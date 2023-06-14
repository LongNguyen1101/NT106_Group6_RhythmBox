using Microsoft.AspNetCore.Mvc;
using RhythmBox.Data;
using RhythmBox.Models;
using RhythmBox.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace RhythmBox.Repositories.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
	{
        private readonly RhythmboxdbContext _context;
        private readonly ITrack _track;

        public TrackController(RhythmboxdbContext context, ITrack track)
        {
            _context = context;
            _track = track;
        }

        [HttpPost("addTrack")]
        public async Task<IActionResult> addTrack([FromBody] AddTrack model)
        {
            try
            {
                var check = await _track.postAddTrack(_context, model.albumId, model.artistId, model.title,
                                                    model.duration, model.genre, model.releaseDate, model.plays, model.song, model.lyrics);

                if (check.Contains("Error")) return BadRequest(check);
                else return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteTrack")]
        public async Task<IActionResult> deleteTrack(int trackId)
        {
            try
            {
                var check = await _track.deleteTrack(_context, trackId);

                if (check.Contains("Error")) return BadRequest(check);
                else return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("updateTrack")]
        public async Task<IActionResult> updateTrack([FromBody] UpdateTrack model)
        {
            try
            {
                var check = await _track.updateTrack(_context, model.trackId, model.title, model.genre, model.releaseDate);

                if (check.Contains("Error")) return BadRequest(check);
                else return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
	}
}

