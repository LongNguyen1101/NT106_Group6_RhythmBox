using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
	public interface IDbAlbums
	{
		// Create new album
		Task postCreateAlbumAsync(RhythmboxdbContext context, int artistId, string title, TimeSpan duration, DateTime releaseDate, FileDetails image);

		// Get 10 album (title and cover) for display 
		Task getAllAlbumForDisplayAsync(RhythmboxdbContext context);

		// Get informatin of single album
		Task getAlbumAsync(RhythmboxdbContext context, int albumId);

		// Get all tracsk in album
		Task getTracksInAlbumAsync(RhythmboxdbContext context, int albumId);

		// Delete album
		Task deleteAlbumAsync(RhythmboxdbContext context, int albumId);

		// Update information of album
		Task postUpdateInformationAsync(RhythmboxdbContext context, int artistId, string title, TimeSpan duration, DateTime releaseDate, FileDetails image);

		// Download single album 
		Task getDownloadAlbumAsync(RhythmboxdbContext context, int albumId);

		// Add all tracks of album to playlist
        Task postAlbumToPlaylistAsync(RhythmboxdbContext context, int playlistId, int albumId);

		// Find album by using character
        Task getFindAlbumAsync(RhythmboxdbContext context, string searchString);

        // Calculate the total of duraion per track and update to duration of album
        Task<int> postCalculateTotalDurationAsync(RhythmboxdbContext context);

		// Get all album - for testing only
		Task<List<Album>?> getAllAlbumAsync(RhythmboxdbContext context);
    }
}

