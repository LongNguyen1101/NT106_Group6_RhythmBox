using System;
using RhythmBox.Data;
using RhythmBox.Repositories.Interface;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Services
{
	public class ArtistsLib : IArtistsLib
	{
        private readonly IConfiguration _config;
        private readonly IFileShare _fileShare;

        public ArtistsLib(IConfiguration config, IFileShare fileShare)
		{
			_config = config;
			_fileShare = fileShare;
		}

        public async Task<int> deleteArtistsLibAsync(RhythmboxdbContext context, int artistsLibId)
        {
            try
            {
                var artistsLib = await Task.Run(() => context.ArtistsLibs
                                                            .Where(con => con.ArtistsLibId == artistsLibId)
                                                            .SingleOrDefault());
                if (artistsLib != null)
                {
                    context.ArtistsLibs.Remove(artistsLib);
                    context.SaveChanges();
                }
                else return -1; // albumsLib not exist

                return 1;
            }
            catch { return -1; } // Error
        }

        public async Task<List<(int?, string, byte[])>?> getArtistsLibraryAsync(RhythmboxdbContext context, int userId)
        {
            try
            {
                var query = await Task.Run(() => from artistsLib in context.ArtistsLibs
                                                 join artist in context.Artists on artistsLib.ArtistsId equals artist.ArtistsId
                                                 select new
                                                 {
                                                     artistId = artistsLib.ArtistsId,
                                                     name = artist.FullName,
                                                     avaUrl = artist.ArtistsImage
                                                 });

                if (query != null)
                {
                    List<(int?, string, byte[])> list = new List<(int?, string, byte[])>();

                    foreach (var artist in query)
                    {
                        list.Add((artist.artistId, artist.name, await _fileShare.fileDownloadAsync(artist.avaUrl)));
                    }

                    return list;
                }
                else return null;
            }
            catch { return null; }
        }

        public async Task<int> postAddArtistToLibAsync(RhythmboxdbContext context, int userId, int artistId)
        {
            try
            {
                var checkArtistLib = await Task.Run(() => context.ArtistsLibs.Any(con => con.ArtistsId == artistId));

                if (!checkArtistLib)
                {
                    var artistsLib = new RhythmBox.Models.ArtistsLib()
                    {
                        ArtistsId = artistId,
                        UsersId = userId
                    };

                    await Task.Run(() =>
                    {
                        context.ArtistsLibs.Add(artistsLib);
                        context.SaveChanges();
                    });

                    return 1; // Add successful
                }

                return 0; // Artist already exist
            }
            catch { return -1; } // Error
        }
    }
}

