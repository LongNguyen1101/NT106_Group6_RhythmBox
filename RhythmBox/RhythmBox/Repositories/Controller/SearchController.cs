using System;
using Microsoft.AspNetCore.Mvc;
using RhythmBox.Data;
using RhythmBox.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using RhythmBox.Repositories.Interface;

namespace RhythmBox.Repositories
{
    [Route("api/[controller]")]
    [ApiController]
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
		public async Task<IActionResult> getAlbums(string searchString)
		{
			if (!string.IsNullOrEmpty(searchString))
			{
				try
				{
					var list = await _search.GetAlbumsLoad(_context, searchString);

					if (list != null)
					{
						List<string> title = list.Where(con => con.Item2 != null)
												.Select(con => con.Item2)
												.ToList();

						return Ok(title);
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
		public async Task<IActionResult> getArtists(string searchString)
		{
			if (!string.IsNullOrEmpty(searchString))
			{
				try
				{
					var list = await _search.GetArtistsLoad(_context, searchString);

                    if (list != null)
                    {
                        List<string> title = list.Where(con => con.Item2 != null)
                                                .Select(con => con.Item2)
                                                .ToList();

                        return Ok(title);
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
		public async Task<IActionResult> getTracks(string searchString)
		{
			if (!string.IsNullOrEmpty(searchString))
			{
				try
				{
					var list = await _search.getTracksLoad(_context, searchString);

                    if (list != null)
                    {
                        List<string> title = list.Where(con => con.Item2 != null)
                                                .Select(con => con.Item2)
                                                .ToList();

                        return Ok(title);
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
		public async Task<IActionResult> getUsers(string searchString)
		{
			if (!string.IsNullOrEmpty(searchString))
			{
				try
				{
					var list = await _search.GetUsersLoad(_context, searchString);

                    if (list != null)
                    {
                        List<string> title = list.Where(con => con.Item2 != null)
                                                .Select(con => con.Item2)
                                                .ToList();

                        return Ok(title);
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

