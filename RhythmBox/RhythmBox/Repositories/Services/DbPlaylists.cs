using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using RhythmBox.Data;
using RhythmBox.Models;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;


namespace RhythmBox.Repositories.Services
{
	public class DbPlaylists
	{
        private readonly IConfiguration _config;
        private readonly IFileShare _fileShare;

        public DbPlaylists(IConfiguration config, IFileShare fileShare)
		{
			_config = config;
			_fileShare = fileShare;
		}

		public async Task<Boolean> postCreatePlaylistAsync(RhythmboxdbContext context, int userId, int trackId, string title, TimeSpan duration)
		{
			try
			{
				if (title == null)
				{
					int defaultPlaylistNumber = context.Playlists.Count() + 1;

					title = $"My Playlist #{defaultPlaylistNumber}";
				}

				var playlist = new Playlist()
				{
					UsersId = userId,
					TracksId = trackId,
					Title = title,
					Duration = duration
				};

				context.Playlists.Add(playlist);
				await context.SaveChangesAsync();

				return true; // Create successful
			}
			catch { return false; } // Error
		}


    }
}

