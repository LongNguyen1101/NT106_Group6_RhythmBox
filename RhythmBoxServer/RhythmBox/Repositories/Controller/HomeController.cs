using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RhythmBox.Data;
using RhythmBox.Models.DTO;
using RhythmBox.Repositories.Interface;
using System.Data;

namespace RhythmBox.Repositories.Controller
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class HomeController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHome _home;

        public HomeController(IUserService userService, IHome home)
        {
            _userService = userService;
            _home = home;
        }

        [HttpGet("album")]
        public ActionResult AlbumLoad()
        {
            return Ok(_home.getAlbums());
        }

        [HttpGet("artist")]
        public ActionResult ArtistLoad()
        {
            return Ok(_home.getArtists());
        }

        [HttpGet("track")]
        public ActionResult TrackLoad()
        {
            return Ok(_home.getTracks());
        }

        [HttpGet("recentlyPlayed")]
        public ActionResult RecentlyPlayedLoad()
        {
            return Ok(_home.getRecentlyPlayed());
        }
        [HttpGet("profile")]
        public ActionResult ProfileLoad()
        {
            return Ok(_home.getProfile());
        }
        [HttpPost("postProfile")]
        public ActionResult ProfileUpdate([FromBody] NewProfile user) 
        {
            return _home.updateProfile(user.userName, user.Email, user.Gender, user.birthday)? Ok(): BadRequest();
        }

    }
}
