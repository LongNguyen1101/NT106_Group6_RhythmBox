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
    public class HistoryController : ControllerBase
	{
        private readonly RhythmboxdbContext _context;
        private readonly IHistory _history;
        private readonly IUserService _user;

        public HistoryController(RhythmboxdbContext context, IHistory history, IUserService user)
		{
            _context = context;
            _history = history;
            _user = user;
        }

        [HttpGet("getHistories")]
        public async Task<IActionResult> getHistories()
        {
            try
            {
                var histories = await _history.getHistoryLoading(_context, int.Parse(_user.getUserID()));

                if (histories != null)
                {
                    string json = JsonConvert.SerializeObject(histories);

                    return Ok(json);
                }

                return BadRequest("Error");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addHistory")]
        public async Task<IActionResult> addHistory(int trackId, DateTime playedAt)
        {
            try
            {
                var check = await _history.postAddHistory(_context, int.Parse(_user.getUserID()), trackId, playedAt);

                if (check.Contains("Error")) return BadRequest(check);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpOptions("deleteHistory")]
        public async Task<IActionResult> deleteHistory(int historyId)
        {
            try
            {
                var check = await _history.postDeleteHistory(_context, historyId);

                if (check.Contains("Error")) return BadRequest(check);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
	}
}

