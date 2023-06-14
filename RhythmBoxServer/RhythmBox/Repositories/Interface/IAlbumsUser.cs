using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
	public interface IAlbumsUser
	{
        // Get album for display
        Task<List<(int, string?, byte[])>?> getAlbumLoading(RhythmboxdbContext context, int artistId);

        // Get informatin of single album
        Task<(int, int?, string?, TimeSpan?, DateTime?)?> getInfoAlbumAsync(RhythmboxdbContext context, int albumId);

        // Get all tracks for displaying
        Task<List<(string, byte[])>?> getTracksLoadingAsync(RhythmboxdbContext context, int albumId);

        // Get other albums for displaying
        Task<List<(int, string?, byte[])>?> getOtherAlbums(RhythmboxdbContext context, int albumId, int artistId);

        // Find album by using character
        Task<List<(int, string?, byte[])>?> getFindAlbumAsync(RhythmboxdbContext context, string searchString);
    }
}

