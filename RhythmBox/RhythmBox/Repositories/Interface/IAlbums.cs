using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
	public interface IAlbums
	{
		// Create new album
		Task<string> postCreateAlbumAsync(RhythmboxdbContext context, int artistId, string title, DateTime releaseDate, byte[] image);

        // Add track to album
        Task<string> postAddTrackToAlbumAsync(RhythmboxdbContext context, int albumId, int trackId);

        // Get album for display
        Task<List<(int, string?, byte[])>?> getAlbumLoading(RhythmboxdbContext context, int artistId);

        // Get informatin of single album
        Task<(int, int?, string?, TimeSpan?, DateTime?)?> getInfoAlbumAsync(RhythmboxdbContext context, int albumId);

        // Get all tracks for displaying
        Task<List<(string, byte[])>?> getTracksLoadingAsync(RhythmboxdbContext context, int albumId);

        // Get other albums for displaying
        Task<List<(int, string?, byte[])>?> getOtherAlbums(RhythmboxdbContext context, int albumId, int artistId);

        // Delete album
        Task<string> deleteAlbumAsync(RhythmboxdbContext context, int albumId);

        // Delete track
        Task<string> deleteTrackAsync(RhythmboxdbContext context, int albumId, int trackId);

        // Update information of album
        Task<string> postUpdateInformationAsync(RhythmboxdbContext context, int albumId, string? title, DateTime? releaseDate, byte[]? image);

        // Find album by using character
        Task<List<(int, string?, byte[])>?> getFindAlbumAsync(RhythmboxdbContext context, string searchString);
    }
}

