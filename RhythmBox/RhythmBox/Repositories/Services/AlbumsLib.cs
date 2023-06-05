using System;
using RhythmBox.Data;
using RhythmBox.Repositories.Interface;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Services
{
	public class AlbumsLib : IAlbumsLib
	{
		private readonly IConfiguration _config;
		private readonly IFileShare _fileShare;

		public AlbumsLib(IConfiguration config, IFileShare fileShare)
		{
			_config = config;
			_fileShare = fileShare;
		}

        public async Task<int> deleteAlbumLibAsync(RhythmboxdbContext context, int albumLibId)
        {
            try
            {
                var albumsLib = await Task.Run(() => context.AlbumsLibs
                                                            .Where(con => con.AlbumsLibId == albumLibId)
                                                            .SingleOrDefault());
                if (albumsLib != null)
                {
                    context.AlbumsLibs.Remove(albumsLib);
                    context.SaveChanges();
                }
                else return -1; // albumsLib not exist

                return 1;
            }
            catch { return -1; } // Error
        }

        public async Task<List<(int?, string, byte[])>?> getAlbumsLibraryAsync(RhythmboxdbContext context, int userId)
        {
            try
            {
                var query = await Task.Run(() => from albumsLib in context.AlbumsLibs
                                                 join albums in context.Albums on albumsLib.AlbumsId equals albums.AlbumsId
                                                 select new
                                                 {
                                                     albumId = albumsLib.AlbumsId,
                                                     title = albums.Title,
                                                     coverUrl = albums.AlbumImage
                                                 });

                if (query != null)
                {
                    List<(int?, string, byte[])> list = new List<(int?, string, byte[])>();

                    foreach (var album in query)
                    {
                        list.Add((album.albumId, album.title, await _fileShare.fileAlbumCoverDownloadAsync(album.coverUrl)));
                    }

                    return list;
                }
                else return null;
            }
            catch { return null; }
        }

        public async Task<int> postAddAlbumToLibAsync(RhythmboxdbContext context, int userId, int albumId)
        {
            try
            {
                var checkAlbumsLib = await Task.Run(() => context.AlbumsLibs.Any(con => con.AlbumsId == albumId));

                if (!checkAlbumsLib)
                {
                    var albumsLib = new RhythmBox.Models.AlbumsLib()
                    {
                        AlbumsId = albumId,
                        UsersId = userId
                    };

                    await Task.Run(() =>
                    {
                        context.AlbumsLibs.Add(albumsLib);
                        context.SaveChanges();
                    });

                    return 1;
                }

                return 0; // Album already exist
            }
            catch { return -1; } // Error
        }
    }
}

