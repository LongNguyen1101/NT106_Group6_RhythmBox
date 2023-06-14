using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
	public interface IArtistsLib
	{
        // Add artist to Artist Library
        Task<int> postAddArtistToLibAsync(RhythmboxdbContext context, int userId, int artistId);

        // Get all artist of Artist Library
        Task<List<(int?, string, byte[])>?> getArtistsLibraryAsync(RhythmboxdbContext context, int userId);

        // Delete single aritst from Artist Library
        Task<int> deleteArtistsLibAsync(RhythmboxdbContext context, int artistsLibId);
    }
}

