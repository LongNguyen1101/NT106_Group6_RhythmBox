using RhythmBox.Data;
using RhythmBox.Models;
using RhythmBox.Repositories.Interface;

namespace RhythmBox.Repositories
{
	public class Search : ISearch
	{
		private readonly IConfiguration _config;
        private readonly IFileShare _fileShare;

		public Search(IConfiguration config, IFileShare fileShare)
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
                List<(int, string, byte[], byte[])>? list = new List<(int, string, byte[], byte[])>();

                await Task.Run(async () =>
                {
                    foreach (var artist in artists)
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

        public async Task<List<(int, string, byte[])>?> getTracksLoad(RhythmboxdbContext context, string searchString)
        {
            var tracks = await Task.Run(() => context.Tracks
                                                       .Where(con => con.Title != null && con.Title.Contains(searchString))
                                                       .ToList());

            try
            {
                List<(int, string, byte[])>? list = new List<(int, string, byte[])>();

                await Task.Run(async () =>
                {
                    foreach (var track in tracks)
                    {
                        if (track.Title != null && track.TrackImage != null)
                        {
                            if (track.TrackImage.Replace("https://rhythmboxstorage.file.core.windows.net/resource/", "").Split('/').Length == 3)
                                list.Add((track.TracksId, track.Title, await _fileShare.fileDownloadAsync(track.TrackImage)));
                            else list.Add((track.TracksId, track.Title, await _fileShare.fileAlbumCoverDownloadAsync(track.TrackImage)));
                        }
                    }
                });

                return list;
            }
            catch { return null; }
        }

        public async Task<List<(int, string, byte[])>?> GetUsersLoad(RhythmboxdbContext context, string searchString)
        {
            var users = await Task.Run(() => context.Users
                                                    .Where(con => con.UserName != null && con.UserName.Contains(searchString)));

            try
            {
                List<(int, string, byte[])>? list = new List<(int, string, byte[])>();

                await Task.Run(async () =>
                {
                    foreach (var user in users)
                    {
                        if (user.UserName != null && user.AvaUrl != null)
                            list.Add((user.UsersId, user.UserName, await _fileShare.fileDownloadAsync(user.AvaUrl)));
                    }
                });

                return list;
            }
            catch { return null; }
        }
    }
}

