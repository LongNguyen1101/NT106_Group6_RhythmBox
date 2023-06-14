using RhythmBox.Data;
using RhythmBox.Models;
using RhythmBox.Repositories.Interface;

namespace RhythmBox.Repositories.Services
{
	public class Track : ITrack
	{
        private readonly IConfiguration _config;
        private readonly IFileShare _fileShare;

        public Track(IConfiguration config, IFileShare fileShare)
        {
            _config = config;
            _fileShare = fileShare;
        }

        public async Task<string> deleteTrack(RhythmboxdbContext context, int trackId)
        {
            try
            {
                var track = await Task.Run(() => context.Tracks
                                                        .Where(con => con.TracksId == trackId)
                                                        .SingleOrDefault());


                if (track != null)
                {
                    if (track.AlbumsId != null)
                    {
                        var album = await Task.Run(() => context.Albums
                                                                .Where(con => con.AlbumsId == track.AlbumsId)
                                                                .SingleOrDefault());

                        if (album != null)
                        {
                            await Task.Run(() =>
                            {
                                album.Duration = TimeSpan.FromSeconds(album.Duration.GetValueOrDefault().TotalSeconds -
                                                                        track.Duration.GetValueOrDefault().TotalSeconds);

                                context.Albums.Update(album);
                            });
                        }

                        var playlistTracks = await Task.Run(() => context.PlaylistTracks
                                                                    .Where(con => con.TrackId == track.TracksId)
                                                                    .ToList());

                        if (playlistTracks != null)
                        {
                            await Task.Run(() =>
                            {
                                foreach (var tracks in playlistTracks)
                                {
                                    var playlist = context.Playlists
                                                            .Where(con => con.PlaylistId == tracks.PlaylistId)
                                                            .SingleOrDefault();

                                    if (playlist != null)
                                    {
                                        playlist.Duration = TimeSpan.FromSeconds(playlist.Duration.GetValueOrDefault().TotalSeconds -
                                                                                    track.Duration.GetValueOrDefault().TotalSeconds);

                                        context.Playlists.Update(playlist);
                                    }
                                }
                            });

                            context.PlaylistTracks.RemoveRange(playlistTracks);
                        }
                    }

                    await Task.Run(() =>
                    {
                        context.Tracks.Remove(track);
                        context.SaveChanges();
                    });

                    return "Delete successful";
                }
                else return $"Error: track not found";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public async Task<string> postAddTrack(RhythmboxdbContext context, int albumId, int artistId, string title, TimeSpan duration,
                                                string genre, DateTime releaseDate, int plays, byte[] song, byte[] lyric)
        {
            try
            {
                if (!await Task.Run(() => context.Tracks.Any(con => con.Title == title)))
                    return $"Error: Track is aleardy exsits";

                var newTrack = new Models.Track()
                {
                    AlbumsId = albumId,
                    ArtistsId = artistId,
                    Title = title,
                    Duration = duration,
                    Genre = genre,
                    ReleaseDate = releaseDate,
                    Plays = plays
                };

                await Task.Run(() =>
                {
                    context.Tracks.Add(newTrack);
                    context.SaveChanges();
                });

                var track = await Task.Run(() => context.Tracks
                                                        .Where(con => con.Title == title)
                                                        .SingleOrDefault());

                if (track != null)
                {
                    track.SongUrl = await _fileShare.fileUploadAsync(new FileContent(song, title), track.ArtistsId.ToString()!, "Tracks", false);
                    track.LyricsUrl = await _fileShare.fileUploadAsync(new FileContent(lyric, title), track.ArtistsId.ToString()!, "Lyrics", false);

                    if (track.AlbumsId != null)
                    {
                        track.TrackImage = await Task.Run(() => context.Albums
                                                                    .Where(con => con.AlbumsId == track.AlbumsId)
                                                                    .Select(se => se.AlbumImage)
                                                                    .SingleOrDefault());
                    }
                    else
                    {
                        track.TrackImage = await Task.Run(() => context.Artists
                                                                    .Where(con => con.ArtistsId == track.ArtistsId)
                                                                    .Select(se => se.ArtistsImage)
                                                                    .SingleOrDefault());
                    }

                    await Task.Run(() =>
                    {
                        context.Tracks.Update(track);
                        context.SaveChanges();
                    });

                    return "Add successful";
                }
                else return $"Error: Add track failed";

            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public async Task<string> updateTrack(RhythmboxdbContext context, int trackId, string title, string genre, DateTime releaseDate)
        {
            try
            {
                var track = await Task.Run(() => context.Tracks
                                                        .Where(con => con.TracksId == trackId)
                                                        .SingleOrDefault());

                if (track != null)
                {
                    await Task.Run(() =>
                    {
                        if (track.Title != title) track.Title = title;
                        if (track.Genre != genre) track.Genre = genre;
                        if (track.ReleaseDate != releaseDate) track.ReleaseDate = releaseDate;

                        context.Tracks.Update(track);
                        context.SaveChanges();
                    });

                    return "Update successful";
                }
                else return "Error: track not found";

            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}

