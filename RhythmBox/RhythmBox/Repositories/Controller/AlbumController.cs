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
    [ApiController]
    public class AlbumController : ControllerBase
	{
        private readonly RhythmboxdbContext _context;
		private readonly IAlbums _albums;
        private readonly IUserService _user;

        public AlbumController(RhythmboxdbContext context, IAlbums albums, IUserService user)
		{
			_context = context;
			_albums = albums;
			_user = user;
		}

		// check
		[HttpPost("createAlbum")]
		public async Task<IActionResult> createAlbum(int artistId, string title, DateTime releaseDate, [FromForm] FileDetails image)
		{
			try
			{
				byte[]? imageBytes = null;

				using (MemoryStream stream = new MemoryStream())
				{
					await image.fileDetail.CopyToAsync(stream);
					imageBytes = stream.ToArray();
				}

				var check = await _albums.postCreateAlbumAsync(_context, artistId, title, releaseDate, imageBytes);

				if (check.Contains("Error")) return BadRequest(check);

				return StatusCode(201);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("addTrack")]
		public async Task<IActionResult> addTrack(int albumId, int trackId)
		{
			try
			{
				var check = await _albums.postAddTrackToAlbumAsync(_context, albumId, trackId);

                if (check.Contains("Error")) return BadRequest(check);

				return StatusCode(201);
            }
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("getInfoAlbum")]
		public async Task<IActionResult> getInfoAlbum(int albumId)
		{
			try
			{
				var info = await _albums.getInfoAlbumAsync(_context, albumId);

				if (info != null)
				{
					string json = JsonConvert.SerializeObject(info);

					return Ok(json);
				}

				return BadRequest("Error");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("getOtherAlbum")]
		public async Task<IActionResult> getOtherAlbum(int albumId, int artistId)
		{
			try
			{
				var albums = await _albums.getOtherAlbums(_context, albumId, artistId);

				if (albums != null)
				{
					string json = JsonConvert.SerializeObject(albums);

					return Ok(json);
				}
				else return BadRequest("Not found any album");
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

		// check
		[HttpPost("updateInformation")]
		public async Task<IActionResult> updateInformation(int albumId, string? title, DateTime? releaseDate, [FromForm] FileDetails? image)
		{
			try
			{
				byte[]? imageBytes = null;

				if (image != null)
				{
					using (MemoryStream stream = new MemoryStream())
					{
						await image.fileDetail.CopyToAsync(stream);
						imageBytes = stream.ToArray();
					}
				}

                var check = await _albums.postUpdateInformationAsync(_context, albumId, title, releaseDate, imageBytes);

				if (check.Contains("Error")) return BadRequest(check);

				return StatusCode(201);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("findAlbum")]
		public async Task<IActionResult> findAlbum(string searchString)
		{
			try
			{
				var list = await _albums.getFindAlbumAsync(_context, searchString);

				if (list != null)
				{
					string json = JsonConvert.SerializeObject(list);

					return Ok(json);
				}

				return BadRequest("No album found");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("albumLoad")]
		public async Task<IActionResult> albumLoading(int artistId)
		{
			try
			{
				var albums = await _albums.getAlbumLoading(_context, artistId);

				if (albums != null)
				{
					string json = JsonConvert.SerializeObject(albums);

					return Ok(json);
				}

				return BadRequest("Other albums not found");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
    }
}

