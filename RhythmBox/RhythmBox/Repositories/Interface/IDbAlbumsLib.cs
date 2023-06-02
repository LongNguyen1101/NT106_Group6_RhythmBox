using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
	public interface IDbAlbumsLib
	{
		Task postCreateAlbumLibAsync(RhythmboxdbContext context, int userId, int albumId);
		Task deleteAlbumLibAsync(RhythmboxdbContext context, int albumLibId);
	}
}

