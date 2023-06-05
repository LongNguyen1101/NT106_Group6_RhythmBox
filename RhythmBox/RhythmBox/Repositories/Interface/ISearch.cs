using System;
using RhythmBox.Models;
using RhythmBox.Data;

namespace RhythmBox.Repositories.Interface
{
	public interface ISearch
	{
		// Search for tracks
		Task<List<(int, string, byte[])>?> getTracksLoad(RhythmboxdbContext context, string searchString);

		// Search for artist
		Task<List<(int, string, byte[], byte[])>?> GetArtistsLoad(RhythmboxdbContext context, string searchString);

		// Search for albums
		Task<List<(int, string, byte[])>?> GetAlbumsLoad(RhythmboxdbContext context, string searchString);

		// Search for users
		Task<List<(int, string, byte[])>?> GetUsersLoad(RhythmboxdbContext context, string searchString);
	}
}
