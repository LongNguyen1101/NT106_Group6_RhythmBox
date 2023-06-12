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
    [ApiController, Authorize]
    public class SearchController : ControllerBase
	{
		private readonly RhythmboxdbContext _context;
		private readonly ISearch _search;

		public SearchController(RhythmboxdbContext context, ISearch search)
		{
			_context = context;
			_search = search;
		}

		[HttpGet("getAlbums")]
		public async Task<IActionResult> getAlbums([FromBody] string searchString)
		{
			if (!string.IsNullOrEmpty(searchString))
			{
				try
				{
					var list = await _search.GetAlbumsLoad(_context, searchString);

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
			}

			return BadRequest("Missing keyword");
		}

		[HttpGet("getArtist")]
		public async Task<IActionResult> getArtists([FromBody] string searchString)
		{
			if (!string.IsNullOrEmpty(searchString))
			{
				try
				{
					var list = await _search.GetArtistsLoad(_context, searchString);

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
			}

			return BadRequest("Error");
		}

		[HttpGet("getTracks")]
		public async Task<IActionResult> getTracks([FromBody] string searchString)
		{
			if (!string.IsNullOrEmpty(searchString))
			{
				try
				{
					var list = await _search.getTracksLoad(_context, searchString);

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
			}

			return BadRequest("Error");
		}

		[HttpGet("getUsers")]
		public async Task<IActionResult> getUsers([FromBody] string searchString)
		{
			if (!string.IsNullOrEmpty(searchString))
			{
				try
				{
					var list = await _search.GetUsersLoad(_context, searchString);

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
			}

			return BadRequest("Error");
		}
	}
}

