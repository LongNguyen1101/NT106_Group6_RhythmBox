using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using RhythmBox.Data;
using RhythmBox.Models;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using RhythmBox.Repositories.Interface;

namespace RhythmBox.Repositories
{
	public class Playlists : IPlaylist
	{
		private readonly IConfiguration _config;
		private readonly IFileShare _fileShare;

		public Playlists(IConfiguration config, IFileShare fileShare)
		{
			_config = config;
			_fileShare = fileShare;
		}

		public async Task<int> deletePlaylistAsync(RhythmboxdbContext context, int playlistId)
		{
			try
			{
				var playlist =  await Task.Run(() => context.Playlists
									.Where(con => con.PlaylistId == playlistId)
									.SingleOrDefault());

				var playlistTrack = await Task.Run(() => context.PlaylistTracks
																.Where(con => con.PlaylistId == playlistId)
																.ToList());

				if (playlist != null)
				{
					await Task.Run(() =>
					{
						context.Playlists.Remove(playlist);

						foreach (var track in playlistTrack)
						{
							context.PlaylistTracks.Remove(track);
						}

						context.SaveChanges();
					});
				}
				else return 0; // Playlist not found

				return 1; // Delete successful
			}
			catch { return -1; } // Error
		}

        public async Task<int> deleteTrackAsync(RhythmboxdbContext context, int playlistId, int trackId)
        {
            try
			{
				var track = await Task.Run(() => context.PlaylistTracks
														.Where(con => con.PlaylistId == playlistId && con.TrackId == trackId)
														.SingleOrDefault());

				if (track != null)
				{
					await Task.Run(() =>
					{
						context.PlaylistTracks.Remove(track);
						context.SaveChanges();
					});
					return 1; // Delete successful
				}
				else return 0; // Playlist or track not found
			}
			catch { return -1; }
        }

        public async Task<(string?, TimeSpan?)?> getDuration(RhythmboxdbContext context, int playlistId)
        {
            try
			{
                var duration = await Task.Run(() => context.Playlists
                                                            .Where(con => con.PlaylistId == playlistId)
                                                            .Select(se => se.Duration)
                                                            .SingleOrDefault());

				if (duration != null) return (null, duration);
				else return null;
            }
			catch (Exception ex)
			{
				return (ex.Message, null);
			}
        }

        public async Task<List<(int, string?, byte[])>?> getPlaylistsLoadAsync(RhythmboxdbContext context, int userId)
		{
			try
			{
				var playlists = await Task.Run(() => context.Playlists
															.Where(con => con.UsersId == userId)
															.ToList());


				if (playlists != null)
				{
					List<(int, string?, byte[])> list = new List<(int, string?, byte[])>();

					foreach (var playlist in playlists)
					{
						if (playlist.PlaylistCover != null)
						{
							if (playlist.PlaylistCover.Contains("Albums"))
								list.Add((playlist.PlaylistId, playlist.Title, await _fileShare.fileAlbumCoverDownloadAsync(playlist.PlaylistCover)));
							else list.Add((playlist.PlaylistId, playlist.Title, await _fileShare.fileDownloadAsync(playlist.PlaylistCover)));
						}
					}

					return list;
				}
				else return null;
			}
			catch { return null; }
		}

        public async Task<List<(string, byte[])>?> getTracksLoadingAsync(RhythmboxdbContext context, int playlistId)
        {
            try
			{
				var query = await Task.Run(() => from playlistTrack in context.PlaylistTracks
												  join track in context.Tracks
												  on playlistTrack.TrackId equals track.TracksId
												  where playlistTrack.PlaylistId == playlistId
												  select new
												  {
													  track.TracksId,
													  track.Title,
													  track.TrackImage
												  });

				var tracks = query.ToList();

				if (tracks != null)
				{
					List<(string, byte[])> list = new List<(string, byte[])>();

					await Task.Run(async () =>
					{
						foreach (var track in tracks)
						{
							byte[] bytes;

							if (track.TrackImage.Contains("Albums")) bytes = await _fileShare.fileAlbumCoverDownloadAsync(track.TrackImage);
							else bytes = await _fileShare.fileDownloadAsync(track.TrackImage);

							list.Add((track.Title, bytes));
						}
					});

					return list;
				}
				else return null;
			}
			catch { return null; }
        }

        public async Task<int> postAddAlbumToPlaylistAsync(RhythmboxdbContext context, int playlistId, int albumId)
		{
			try
			{
				var tracks = await Task.Run(() => context.Tracks
															.Where(con => con.AlbumsId == albumId)
															.Select(con => new { con.TracksId, con.Duration })
															.ToList());

				var playlist = await Task.Run(() => context.Playlists
															.Where(con => con.PlaylistId == playlistId)
															.SingleOrDefault());

				if (tracks != null && playlist != null)
				{
					await Task.Run(() =>
					{
						List<PlaylistTrack> playlistsTrack = new List<PlaylistTrack>();

						double totalDurationSeconds = 0.0;

						foreach (var track in tracks)
						{
							if (!context.PlaylistTracks.Any(con => con.PlaylistId == playlistId && con.TrackId == track.TracksId))
							{
								playlistsTrack.Add(new PlaylistTrack()
								{
									PlaylistId = playlistId,
									TrackId = track.TracksId
								});

								totalDurationSeconds += track.Duration.GetValueOrDefault().TotalSeconds;
							}
						}

						totalDurationSeconds += playlist.Duration.GetValueOrDefault().TotalSeconds;
						TimeSpan timeSpan = TimeSpan.FromSeconds(totalDurationSeconds);
						playlist.Duration = timeSpan;

						if (!context.PlaylistTracks.Any(con => con.PlaylistId == playlistId))
						{
							playlist.PlaylistCover = context.Tracks
															.Where(con => con.TracksId == tracks.FirstOrDefault()!.TracksId)
															.Select(se => se.TrackImage)
															.ToString();
						}

						context.PlaylistTracks.AddRange(playlistsTrack);
						context.Playlists.Update(playlist);

						context.SaveChanges();
					});

					return 1; // Add successfull
				}
				else return 0; // album or playlist not found
			}
			catch { return -1; } // Error
		}

		public async Task<int> postAddTrackToPlaylistAsync(RhythmboxdbContext context, int playlistId, int trackId)
		{
			if (context.PlaylistTracks.Any(con => con.PlaylistId == playlistId && con.TrackId == trackId))
				return -2; // Track already exist

			try
			{
				var playlist = context.Playlists
									.Where(con => con.PlaylistId == playlistId)
									.SingleOrDefault();

				var trackDuration = context.Tracks
										.Where(con => con.TracksId == trackId)
										.Select(se => se.Duration)
										.SingleOrDefault();

				if (playlist != null && trackDuration != null)
				{
					await Task.Run(() =>
					{
						var playlistTrack = new PlaylistTrack()
						{
							PlaylistId = playlistId,
							TrackId = trackId
						};

						double seconds = trackDuration.GetValueOrDefault().TotalSeconds;

						if (playlist.Duration != null)
							playlist.Duration = TimeSpan.FromSeconds(playlist.Duration.GetValueOrDefault().TotalSeconds + seconds);
						else playlist.Duration = TimeSpan.FromSeconds(seconds);

						if (!context.PlaylistTracks.Any(con => con.PlaylistId == playlistId))
						{
							playlist.PlaylistCover = context.Tracks
															.Where(con => con.TracksId == trackId)
															.Select(se => se.TrackImage)
															.ToString();
						}

						context.Playlists.Update(playlist);
						context.PlaylistTracks.Add(playlistTrack);

					});
					context.SaveChanges();

					return 1; // Add successful
				}

				return 0; // Playlist or track not found
			}
			catch { return -1; } // Error
		}

		public async Task<(int, string?, byte[])?> postCreatePlaylistAsync(RhythmboxdbContext context, int userId)
		{
			try
			{
				var existingCount = await Task.Run(() => context.Playlists
											.Where(con => con.UsersId == userId && con.Title != null && con.Title.StartsWith("My Playlist"))
											.Count());

			   
				var playlist = await Task.Run(() => new Playlist()
				{
					UsersId = userId,
					Title = $"My Playlist #{existingCount + 1}",
					Duration = TimeSpan.Parse("00:00:00"),
					PlaylistCover = "https://rhythmboxstorage.file.core.windows.net/resource/playlist/Default/playlist_cover.jpeg"
				});

				context.Playlists.Add(playlist);
				context.SaveChanges();

				return (playlist.PlaylistId, playlist.Title, await _fileShare.fileDownloadAsync(playlist.PlaylistCover!));
			}
			catch { return null; } // Error
		}

		public async Task<int> postUpdateInformationAsync(RhythmboxdbContext context, int playlistId, string newTitle)
		{
			try
			{
				var playlist = await Task.Run(() => context.Playlists
										.Where(con => con.PlaylistId == playlistId)
										.SingleOrDefault());

				if (playlist != null)
				{
					await Task.Run(() =>
					{
						playlist.Title = newTitle;

						context.Playlists.Update(playlist);
						context.SaveChanges();
					});
				}
				else return 0; // Playlist not found

				return 1; // Update successful
			}
			catch { return -1; } // Error
		}
	}
}

