using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
	public interface IDbArtistsLib
	{
        Task postCreateArtistsLibAsync(RhythmboxdbContext context, int userId, int artistId);
        Task deleteArtistsLibAsync(RhythmboxdbContext context, int artistsLibId);
    }
}

