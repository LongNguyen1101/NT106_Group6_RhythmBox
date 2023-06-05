using System;
using RhythmBox.Data;
using RhythmBox.Models;
using RhythmBox.Repositories.Interface;

namespace RhythmBox.Repositories.Services
{
	public class Seach : ISearch
	{
		private readonly IConfiguration _config;
        private readonly FileShare _fileShare;

		public Seach(IConfiguration config, FileShare fileShare)
		{
			_config = config;
            _fileShare = fileShare;
		}

        public async Task<List<(int, string, byte[])>?> GetAlbumsLoad(RhythmboxdbContext context, string searchString)
        {
            try
            {
                var albums = await Task.Run(() => context.Albums
                                                        .Where(con => con.Title != null && con.Title.Contains(searchString))
                                                        .Select(con => new Album
                                                        {
                                                            AlbumsId = con.AlbumsId,
                                                            Title = con.Title,
                                                            AlbumImage = con.AlbumImage
                                                        })
                                                        .ToList());

                List<(int, string, byte[])>? list = new List<(int, string, byte[])>();

                await Task.Run(async () =>
                {
                    foreach (var album in albums)
                    {
                        if (album.Title != null && album.AlbumImage != null)
                            list.Add((album.AlbumsId, album.Title, await _fileShare.fileAlbumCoverDownloadAsync(album.AlbumImage)));
                    }
                });

                return list;
            }
            catch { return null; }
        }
        
        public async Task<List<(int, string, byte[], byte[])>?> GetArtistsLoad(RhythmboxdbContext context, string searchString)
        {
            var artists = await Task.Run(() => context.Artists
                                                       .Where(con => con.FullName != null && con.FullName.Contains(searchString))
                                                       .ToList());

            try
            {
                List<(int, string, byte[], byte[])> list = new List<(int, string, byte[], byte[])>();

                await Task.Run(async () =>
                {
                    foreach(var artist in artists)
                    {
                        if (artist.FullName != null && artist.BioUrl != null && artist.ArtistsImage != null)
                            list.Add((artist.ArtistsId, artist.FullName,
                                await _fileShare.fileDownloadAsync(artist.BioUrl),
                                await _fileShare.fileDownloadAsync(artist.ArtistsImage)));
                    }
                });

                return list;
            }
            catch { return null; }
        }

        public async Task<List<(int, string, byte[], byte[])>?> getTracksLoad(RhythmboxdbContext context, string searchString)
        {
            var tracks = await Task.Run(() => context.Tracks
                                                       .Where(con => con.Title != null && con.Title.Contains(searchString))
                                                       .ToList());

            try
            {
                List<(int, string, byte[], byte[])> list = new List<(int, string, byte[], byte[])>();

                await Task.Run(() =>
                {
                    foreach(var track in tracks)
                    {
                        
                    }
                });

                return list;
            }
            catch { return null; }
        }

        public Task<List<(int, string, byte[])>?> GetUsersLoad(RhythmboxdbContext context, string searchString)
        {
            throw new NotImplementedException();
        }
    }
}

