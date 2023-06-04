using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
	public interface IDbArtist
	{
		// Get 10 artist for display
		Task getAllArtistAsync(RhythmboxdbContext context);

		// Get information of an artist
		Task getArtistInfoAsync(RhythmboxdbContext context, int artistId);

		// Get all tracks of an artist
		Task getArtistTracksAsync(RhythmboxdbContext context, int artistId);

		// Get all album of an artist
		Task getArtistAlbumsAsync(RhythmboxdbContext context, int artistId);

        // Add user to artist
        Task postAddToArtist(RhythmboxdbContext context, int artistId);

        // Find artist using character
        Task getFindArtistAsync(RhythmboxdbContext context, string searchString);
	}
}

