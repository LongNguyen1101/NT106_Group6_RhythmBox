using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
	public interface IDbPlaylist
	{
		Task<Boolean> postCreatePlaylistAsync(RhythmboxdbContext context, int userId, int trackId, string title, TimeSpan duration);
        Task<List<Playlist>?> getPlaylistAsync(RhythmboxdbContext context, int userId);
        Task deletePlaylistAsync(RhythmboxdbContext context, int playlistId);
		Task postTrackToPlaylistAsync(RhythmboxdbContext context, int playlistId, int trackId);
		Task postAlbumToPlaylistAsync(RhythmboxdbContext context, int playlistId, int albumId);
        Task deleteTrackFromPlaylistAsync(RhythmboxdbContext context, int playlistId, int trackId);
		Task postUpdateInformationAsync(RhythmboxdbContext context, int playlistId, string newTitle);
		Task getDownloadPlaylistAsync(RhythmboxdbContext context, int playlistId);
    }
}

