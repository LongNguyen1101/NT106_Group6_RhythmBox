using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
	public interface IDbArtistsLib
	{
        Task postCreateArtistsLibAsync(RhythmboxdbContext context, int userId, int artistId);
        Task<List<ArtistsLib>?> getArtistsLibraryAsync(RhythmboxdbContext context, int userId);
        Task deleteArtistsLibAsync(RhythmboxdbContext context, int artistsLibId);
    }
}

