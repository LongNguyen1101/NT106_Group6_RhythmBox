using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
	public interface IDbArtistsLib
	{
        // Add artist to Artist Library
        Task postAddArtistToLibAsync(RhythmboxdbContext context, int userId, int artistId);

        // Get all artist of Artist Library
        Task<List<ArtistsLib>?> getArtistsLibraryAsync(RhythmboxdbContext context, int userId);

        // Delete single aritst from Artist Library
        Task deleteArtistsLibAsync(RhythmboxdbContext context, int artistsLibId);
    }
}

