using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
	public interface IDbAlbumsLib
	{
		// Add new album to Album Library
		Task postAddAlbumToLibAsync(RhythmboxdbContext context, int userId, int albumId);

		// Get all Album Library
        Task<List<AlbumsLib>?> getAlbumsLibraryAsync(RhythmboxdbContext context, int userId);

		// Delete single album in Album Library
        Task deleteAlbumLibAsync(RhythmboxdbContext context, int albumLibId);
	}
}

