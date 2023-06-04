using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
	public interface IDbPlaylist
	{
		// Create new playlist
		Task<Boolean> postCreatePlaylistAsync(RhythmboxdbContext context, int userId, int trackId, string title, TimeSpan duration);

		// Get information and cover of playlists to display
        Task<List<Playlist>?> getPlaylistsAsync(RhythmboxdbContext context, int userId);

		// Delete playlist
        Task deletePlaylistAsync(RhythmboxdbContext context, int playlistId);

		// Update new title to playlist
		Task postUpdateInformationAsync(RhythmboxdbContext context, int playlistId, string newTitle);

		// Download all tracks in a playlist
		Task getDownloadPlaylistAsync(RhythmboxdbContext context, int playlistId);

		// Calculate the total of duraion per track and update to duration of playlist
		Task<int> postCalculateTotalDurationAsync(RhythmboxdbContext context);

		// Get all playlist - for testing only
		Task<List<Playlist>?> getAllPlaylistAsync(RhythmboxdbContext context);
    }
}

