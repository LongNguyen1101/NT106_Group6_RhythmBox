using System;
using RhythmBox.Data;
using RhythmBox.Models;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace RhythmBox.Repositories.Interface
{
	public interface IPlaylist
	{
		// Create new playlist
		Task<int> postCreatePlaylistAsync(RhythmboxdbContext context, int userId, int trackId);

		// Get information and cover of playlists to display
        Task<List<(int, string?, byte[])>?> getPlaylistsLoadAsync(RhythmboxdbContext context, int userId);

		// Delete playlist
        Task<int> deletePlaylistAsync(RhythmboxdbContext context, int playlistId);

		// Update new title to playlist
		Task<int> postUpdateInformationAsync(RhythmboxdbContext context, int playlistId, string newTitle);

		// Download all tracks in a playlist
		Task<List<byte[]>?> getDownloadPlaylistAsync(RhythmboxdbContext context, int playlistId);

		// Calculate the total of duraion per track and update to duration of playlist
		Task<TimeSpan> postCalculateTotalDurationAsync(RhythmboxdbContext context);

		// Add album to playlist
		Task<int> postAddAlbumToPlaylistAsync(RhythmboxdbContext context, int albumId, int userId);
    }
}

