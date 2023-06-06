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

                if (playlist != null)
                {
                    await Task.Run(() =>
                    {
                        context.Playlists.Remove(playlist);
                        context.SaveChanges();
                    });
                }
                else return 0; // Playlist not found

                return 1; // Delete successful
            }
            catch { return -1; } // Error
        }

        public Task<List<byte[]>?> getDownloadPlaylistAsync(RhythmboxdbContext context, int playlistId)
        {
            throw new NotImplementedException();
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
                            list.Add((playlist.PlaylistId, playlist.Title, await _fileShare.fileDownloadAsync(playlist.PlaylistCover)));
                    }

                    return list;
                }
                else return null;
            }
            catch { return null; }
        }

        public async Task<int> postAddAlbumToPlaylistAsync(RhythmboxdbContext context, int albumId, int userId)
        {
            //try
            //{
            //    var tracks = await Task.Run(() => context.Tracks
            //                            .Where(con => con.AlbumsId == albumId)
            //                            .Select(con => new { con.TracksId, con.Duration }));

            //    if (tracks != null)
            //    {
            //        List<Playlist> playlists = new List<Playlist>();

            //        foreach (var track in tracks)
            //        {
            //            playlists.Add(new Playlist()
            //            {
            //                UsersId = userId,
            //                TracksId = track.TracksId,

            //            });
            //        }
            //    }
            //}
            //catch { return -1; } // Error
            throw new NotImplementedException();
        }

        public Task<TimeSpan> postCalculateTotalDurationAsync(RhythmboxdbContext context)
        {
            throw new NotImplementedException();
        }

        public async Task<int> postCreatePlaylistAsync(RhythmboxdbContext context, int userId, int trackId)
        {
            try
            {
                var existingCount = await Task.Run(() => context.Playlists
                                            .Where(con => con.UsersId == userId && con.Title != null && con.Title.StartsWith("My Playlist"))
                                            .Count());

                await Task.Run(() =>
                {
                    var playlist = new Playlist()
                    {
                        UsersId = userId,
                        TracksId = trackId,
                        Title = $"My Playlist #{existingCount + 1}",
                        Duration = TimeSpan.Parse("00:00:00"),
                        PlaylistCover = "https://rhythmboxstorage.file.core.windows.net/resource/playlist/Default/playlist_cover.jpeg"
                    };

                    context.Playlists.Add(playlist);
                    context.SaveChanges();
                });

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

