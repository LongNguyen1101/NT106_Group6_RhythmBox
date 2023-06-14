using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
	public interface IAlbumsLib
	{
		// Add new album to Album Library
		Task<int> postAddAlbumToLibAsync(RhythmboxdbContext context, int userId, int albumId);

		// Get all Album Library - (int : albumLibId, string : title, byte[] : image)
        Task<List<(int?, string, byte[])>?> getAlbumsLibraryAsync(RhythmboxdbContext context, int userId); 

		// Delete single album in Album Library
        Task<int> deleteAlbumLibAsync(RhythmboxdbContext context, int albumLibId);
	}
}

