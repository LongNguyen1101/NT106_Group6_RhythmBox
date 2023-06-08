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

        public async Task<List<(string, byte[])>?> getDownloadPlaylistAsync(RhythmboxdbContext context, int playlistId)
        {
            try
            {
                var query = await Task.Run(() => from track in context.Tracks
                                                  join playlistTrack in context.PlaylistTracks
                                                  on track.TracksId equals playlistTrack.TrackId
                                                  where(playlistTrack.PlaylistId == playlistId)
                                                  select new
                                                  {
                                                      track.Title,
                                                      track.SongUrl
                                                  });
                var tracks = query.ToList();

                if (tracks != null)
                {
                    List<(string, byte[])> list = new List<(string, byte[])>();

                    await Task.Run(async () =>
                    {

                        foreach (var track in tracks)
                        {
                            list.Add((track.Title, await _fileShare.fileDownloadAsync(track.SongUrl)));
                        }

                    });

                    return list;
                }
                else return null;
            }
            catch { return null; }
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

        public async Task<int> postCreatePlaylistAsync(RhythmboxdbContext context, int userId)
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

                return 1; // Add successful
            }
            catch { return -1; } // Error
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

