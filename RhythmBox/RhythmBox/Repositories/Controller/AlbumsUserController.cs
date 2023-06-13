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
	[ApiController, Authorize]
	public class AlbumsUserController : ControllerBase
	{
		private readonly RhythmboxdbContext _context;
		private readonly IAlbumsUser _albums;
		private readonly IUserService _user;

		public AlbumsUserController(RhythmboxdbContext context, IAlbumsUser albums, IUserService user)
		{
			_context = context;
			_albums = albums;
			_user = user;
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

