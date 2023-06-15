using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RhythmBox.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

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

        [HttpGet("trackID")]
        public async Task<IActionResult> playTrack(int trackID)
        {
            try
            {
                var content = await _play.getTrack(trackID);

                if (content != null)
                {
                    string json = JsonConvert.SerializeObject(content);

                    return Ok(json);
                }

                return BadRequest("Error");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
