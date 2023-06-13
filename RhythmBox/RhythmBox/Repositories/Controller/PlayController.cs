using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RhythmBox.Repositories.Interface;

namespace RhythmBox.Repositories.Controller
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class PlayController : ControllerBase
    {
        private readonly IPlay _play;

        public PlayController(IPlay play)
        {
            _play = play;
        }

        [HttpGet("{trackID}")]
        public async Task<IActionResult> playTrack(int trackID)
        {
            string segmentData = await _play.getTrack(trackID);

            return Ok(segmentData);
        }
    }
}
