using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
	public interface IDbArtist
	{
		Task getAllArtistAsync(RhythmboxdbContext context);
		Task getArtistInfoAsync(RhythmboxdbContext context, int artistId);
		Task getArtistTracksAsync(RhythmboxdbContext context, int artistId);
		Task getArtistAlbumsAsync(RhythmboxdbContext context, int artistId);
		Task getAllTracksOfArtistAsync(RhythmboxdbContext context, int artistId);
		Task getFindArtistAsync(RhythmboxdbContext context, string searchString);
	}
}

