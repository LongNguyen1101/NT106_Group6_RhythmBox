using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using RhythmBox.Data;
using RhythmBox.Models;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using RhythmBox.Repositories.Interface;

namespace RhythmBox.Repositories.Services
{
	public class AlbumsArtist : IAlbumsArtist
	{
        private readonly IConfiguration _config;
        private readonly IFileShare _fileShare;

        public AlbumsArtist(IConfiguration config, IFileShare fileShare)
		{
            _config = config;
            _fileShare = fileShare;
        }

        public async Task<string> postCreateAlbumAsync(RhythmboxdbContext context, int artistId, string title, DateTime releaseDate, byte[] image)
        {
            try
            {
                if (!await Task.Run(() => context.Artists.Any(con => con.ArtistsId == artistId)))
                    return "Error: Artist not found";
                if (await Task.Run(() => context.Albums.Any(con => con.Title == title)))
                    return "Error: Album is already exist";
                else
                {
                    var album = await Task.Run(() => new Album()
                    {
                        ArtistsId = artistId,
                        Title = title,
                        Duration = TimeSpan.Parse("00:00:00"),
                        ReleaseDate = releaseDate,
                        AlbumImage = null
                    });

                    context.Albums.Add(album);
                    context.SaveChanges();

                    album = await Task.Run(() => context.Albums
                                                         .Where(con => con.Title == title)
                                                         .SingleOrDefault());

                    if (album != null)
                    {
                        album.AlbumImage = await _fileShare.fileUploadAsync(new FileContent(image, "cover"),
                                                                            artistId.ToString(), $"Albums/{album.AlbumsId}", false);


                        context.Albums.Update(album);
                        context.SaveChanges();
                    }
                    else return "Error: Somethong wrong when create album";

                    return "Add successful";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> postAddTrackToAlbumAsync(RhythmboxdbContext context, int albumId, int trackId)
        {
            if (!await Task.Run(() => context.Albums.Any(con => con.AlbumsId == albumId)))
                return "Error: Album not found";

            var track = await Task.Run(() => context.Tracks
                                                    .Where(con => con.TracksId == trackId)
                                                    .SingleOrDefault());

            if (track != null)
            {
                if (track.AlbumsId == albumId) return "Error: Track is already in album";
                else if (track.AlbumsId != null) return "Error: Track is alredy in another album";
                else
                {
                    try
                    {
                        var album = await Task.Run(() => context.Albums
                                                                .Where(con => con.AlbumsId == albumId)
                                                                .SingleOrDefault());

                        var trackDuration = track.Duration;

                        if (album != null && trackDuration != null)
                        {
                            await Task.Run(() =>
                            {
                                double seconds = trackDuration.GetValueOrDefault().TotalSeconds;

                                album.Duration = TimeSpan.FromSeconds(album.Duration.GetValueOrDefault().TotalSeconds + seconds);

                                track.AlbumsId = albumId;

                                context.Albums.Update(album);
                                context.Tracks.Update(track);
                            });
                            context.SaveChanges();

                            return "Add successful";
                        }

                        return "Error: Album not found";
                    }
                    catch (Exception ex)
                    {
                        return $"Error: {ex.Message}";
                    }
                }
            }
            else return "Error: track not found";
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

        public async Task<string> deleteAlbumAsync(RhythmboxdbContext context, int albumId)
        {
            try
            {
                var album = await Task.Run(() => context.Albums
                                                        .Where(con => con.AlbumsId == albumId)
                                                        .SingleOrDefault());

                var tracks = await Task.Run(() => context.Tracks
                                                        .Where(con => con.AlbumsId == albumId)
                                                        .ToList());

                if (tracks != null)
                {
                    foreach (var track in tracks)
                    {
                        track.AlbumsId = null;
                        context.Tracks.Update(track);
                    }
                }

                if (album != null)
                {
                    if (album.AlbumImage != null)
                    {
                        try
                        {
                            var check = await _fileShare.fileDelete(album.AlbumImage);
                        }
                        catch (Exception ex)
                        {
                            return $"Error: {ex.Message}";
                        }
                    }

                    await Task.Run(() =>
                    {
                        context.Albums.Remove(album);
                        context.SaveChanges();
                    });

                    return "Delete successful";
                }
                else return "Album not found";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public async Task<string> deleteTrackAsync(RhythmboxdbContext context, int albumId, int trackId)
        {
            try
            {
                var track = await Task.Run(() => context.Tracks
                                                        .Where(con => con.AlbumsId == albumId && con.TracksId == trackId)
                                                        .SingleOrDefault());

                if (track != null)
                {
                    await Task.Run(() =>
                    {
                        track.AlbumsId = null;

                        context.Tracks.Update(track);
                        context.SaveChanges();
                    });

                    return "Delete successful";
                }

                return "Track or album not found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> postUpdateInformationAsync(RhythmboxdbContext context, int albumId, string? title, DateTime? releaseDate, byte[]? image)
        {
            try
            {
                var album = await Task.Run(() => context.Albums
                                                        .Where(con => con.AlbumsId == albumId)
                                                        .SingleOrDefault());

                if (album != null)
                {
                    await Task.Run(async () =>
                    {
                        if (title != album.Title) album.Title = title;
                        if (releaseDate != album.ReleaseDate) album.ReleaseDate = releaseDate;
                        if (image != null)
                        {
                            album.AlbumImage = await _fileShare.fileUploadAsync(new FileContent(image, "cover"),
                                                                                album.ArtistsId.ToString()!, $"Albums/{album.AlbumsId}", true);
                        }

                        context.Albums.Update(album);
                        context.SaveChanges();
                    });

                    return "Update successfull";
                }
                else return "Error: Album not found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

