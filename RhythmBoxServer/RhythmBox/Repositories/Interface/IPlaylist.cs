using RhythmBox.Data;

namespace RhythmBox.Repositories.Interface
{
	public interface IPlaylist
	{
		// Create new playlist
		Task<int> postCreatePlaylistAsync(RhythmboxdbContext context, int userId);

		// Add track to playlist
		Task<int> postAddTrackToPlaylistAsync(RhythmboxdbContext context, int playlistId, int trackId);

		// Add album to playlist
		Task<int> postAddAlbumToPlaylistAsync(RhythmboxdbContext context, int playlistId, int albumId);

		// Get playlistId, title and cover of playlists to display
        Task<List<(int, string?, byte[])>?> getPlaylistsLoadAsync(RhythmboxdbContext context, int userId);

        // Get all tracks for displaying
        Task<List<(string, byte[])>?> getTracksLoadingAsync(RhythmboxdbContext context, int playlistId);

        // Get duration
        Task<(string?, TimeSpan?)?> getDuration(RhythmboxdbContext context, int playlistId);

		// Delete playlist
        Task<int> deletePlaylistAsync(RhythmboxdbContext context, int playlistId);

		// Delete track
		Task<int> deleteTrackAsync(RhythmboxdbContext context, int playlistId, int trackId);

		// Update new title to playlist
		Task<int> postUpdateInformationAsync(RhythmboxdbContext context, int playlistId, string newTitle);
    }
}

