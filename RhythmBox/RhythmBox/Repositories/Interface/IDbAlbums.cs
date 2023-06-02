using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
	public interface IDbAlbums
	{
		Task getAllAlbumAsync(RhythmboxdbContext context);
		Task getAlbumAsync(RhythmboxdbContext context, int albumId);
		Task getTracksInAlbumAsync(RhythmboxdbContext context, int albumId);
		Task postCreateAlbumAsync(RhythmboxdbContext context, int artistId, string title, TimeSpan duration, DateTime releaseDate, FileDetails image);
		Task deleteAlbumAsync(RhythmboxdbContext context, int albumId);
		Task postUpdateInformationAsync(RhythmboxdbContext context, int artistId, string title, TimeSpan duration, DateTime releaseDate, FileDetails image);
		Task getDownloadAlbumAsync(RhythmboxdbContext context, int albumId);
        Task getFindAlbumAsync(RhythmboxdbContext context, string searchString);
    }
}

