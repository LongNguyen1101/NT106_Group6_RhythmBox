using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using RhythmBox.Data;
using RhythmBox.Models;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using RhythmBox.Repositories.Interface;

namespace RhythmBox.Repositories
{
	public class DbPlaylists : IDbPlaylist
	{
        private readonly IConfiguration _config;
        private readonly IFileShare _fileShare;

        public DbPlaylists(IConfiguration config, IFileShare fileShare)
		{
			_config = config;
			_fileShare = fileShare;
		}

        public async Task<int> deletePlaylistAsync(RhythmboxdbContext context, int playlistId)
        {
            try
            {
                var playlist = context.Playlists.FirstOrDefault(con => con.PlaylistId == playlistId);

                if (playlist != null)
                {
                    await Task.Run(() =>
                    {
                        context.Playlists.Remove(playlist);
                        context.SaveChanges();
                    });

                    return 1; // Delete successful
                }
                else return 0; // Playlist not found
            }
            catch { return -1; } // Error
        }

        public async Task<List<byte[]>?> getDownloadPlaylistAsync(RhythmboxdbContext context, int userId)
        {
            try
            {
                var trackIds = await Task.Run(() => context.Playlists
                                                        .Where(con => con.UsersId == userId)
                                                        .Select(e => e.TracksId)
                                                        .ToList());



                List<byte[]>? list = new List<byte[]>();

                await Task.Run(async () =>
                {
                    foreach (var trackId in trackIds)
                    {
                        var songUrl = context.Tracks
                                            .Where(con => con.TracksId == trackId)
                                            .Select(con => con.SongUrl)
                                            .FirstOrDefault();

                        if (songUrl != null)
                        { 
                            list.Add(await _fileShare.fileDownloadAsync(songUrl));
                        }
                    }

                });

                if (list != null) return list;
            }
            catch { return null; }

            return null;
        }

        public Task<List<Playlist>?> getPlaylistsAsync(RhythmboxdbContext context, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<TimeSpan> postCalculateTotalDurationAsync(RhythmboxdbContext context)
        {
            throw new NotImplementedException();
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

        public Task<int> postUpdateInformationAsync(RhythmboxdbContext context, int playlistId, string newTitle)
        {
            throw new NotImplementedException();
        }

        public Task<List<Playlist>?> getAllPlaylistAsync(RhythmboxdbContext context)
        {
            throw new NotImplementedException();
        }

    }
}

