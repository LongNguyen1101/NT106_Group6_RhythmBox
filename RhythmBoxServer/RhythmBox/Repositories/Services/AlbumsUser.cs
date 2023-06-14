using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using RhythmBox.Data;
using RhythmBox.Models;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using RhythmBox.Repositories.Interface;

namespace RhythmBox.Repositories
{
	public class AlbumsUser : IAlbumsUser
	{
        private readonly IConfiguration _config;
        private readonly IFileShare _fileShare;

        public AlbumsUser(IConfiguration config, IFileShare fileShare)
		{
			_config = config;
			_fileShare = fileShare;
		}

        public async Task<(int, int?, string?, TimeSpan?, DateTime?)?> getInfoAlbumAsync(RhythmboxdbContext context, int albumId)
        {
            try
            {
                var album = await Task.Run(() => context.Albums
                                                    .Where(con => con.AlbumsId == albumId)
                                                    .SingleOrDefault());

                if (album != null)
                    return (album.AlbumsId, album.ArtistsId, album.Title, album.Duration, album.ReleaseDate);
                else return null;
            }
            catch 
            {
                return null;
            }
        }

        public async Task<List<(int, string?, byte[])>?> getFindAlbumAsync(RhythmboxdbContext context, string searchString)
        {
            try
            {
                var albums = await Task.Run(() => context.Albums
                                                        .Where(con => con.Title!.Contains(searchString))
                                                        .ToList());

                if (albums != null)
                {
                    List<(int, string?, byte[])> list = new List<(int, string?, byte[])>();

                    await Task.Run(async () =>
                    {
                        foreach (var album in albums)
                        {
                            if (album.AlbumImage != null)
                                list.Add((album.AlbumsId, album.Title, await _fileShare.fileAlbumCoverDownloadAsync(album.AlbumImage)));
                        }
                    });

                    return list;
                }
                else return null;
            }
            catch { return null; }
        }

        public async Task<List<(int, string?, byte[])>?> getOtherAlbums(RhythmboxdbContext context, int albumId, int artistId)
        {
            try
            {
                var albums = await Task.Run(() => context.Albums
                                                            .Where(con => con.AlbumsId != albumId && con.ArtistsId == artistId)
                                                            .ToList());

                if (albums != null)
                {
                    List<(int, string?, byte[])> list = new List<(int, string?, byte[])>();

                    await Task.Run(async () =>
                    {
                        foreach (var album in albums)
                        {
                            if (album.AlbumImage != null)
                                list.Add((album.AlbumsId, album.Title, await _fileShare.fileAlbumCoverDownloadAsync(album.AlbumImage)));
                        }
                    });

                    return list;
                }
                else return null;
            }
            catch { return null; }
        }

        public async Task<List<(string, byte[])>?> getTracksLoadingAsync(RhythmboxdbContext context, int albumId)
        {
            try
            {
                var query = await Task.Run(() => from album in context.Albums
                                                 join track in context.Tracks
                                                 on album.AlbumsId equals track.AlbumsId
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

        public async Task<List<(int, string?, byte[])>?> getAlbumLoading(RhythmboxdbContext context, int artistId)
        {
            try
            {
                var albums = await Task.Run(() => context.Albums
                                                            .Where(con => con.ArtistsId == artistId)
                                                            .ToList());


                if (albums != null)
                {
                    List<(int, string?, byte[])> list = new List<(int, string?, byte[])>();

                    await Task.Run(async () =>
                    {
                        foreach (var album in albums)
                        {
                            if (album.AlbumImage != null)
                            {
                                list.Add((album.AlbumsId, album.Title, await _fileShare.fileAlbumCoverDownloadAsync(album.AlbumImage)));
                            }
                        }
                    });

                    return list;
                }
                else return null;
            }
            catch { return null; }
        }
    }
}

