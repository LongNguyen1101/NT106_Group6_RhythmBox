using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
	public interface IDbTracks
	{
		// Get top 10 tracks for display
		Task<List<(Track?, byte[]?)>?> getTracksDisplayAsync(RhythmboxdbContext context);

		// Get information withdout file mp3 and lyric of single track
        Task getInformationAsync(RhythmboxdbContext context, int trackId);

		// Get file.mp3 of track for user to listen
        Task getMp3TrackAsync(RhythmboxdbContext context, int trackId);

        // Get file lyric of track to show
        Task getLyricTrackAsync(RhythmboxdbContext context, int trackId);

        // Add new track
        Task postCreateTrackAsync(RhythmboxdbContext context, int albumId, int artistId, string tile,
								TimeSpan duration, string genre, DateTime releaseDate, FileDetails track, FileDetails lyrics);

		// Delete a track
		Task deleteTrackAsync(RhythmboxdbContext context, int trackId);

		// Update information of a track
        Task updateInformationAsync(RhythmboxdbContext context, int albumId, int artistId, string tile,
                                TimeSpan duration, string genre, DateTime releaseDate, FileDetails track, FileDetails lyrics);

		// Update file.mp3 to a track
		Task updateMp3TrackAsync(RhythmboxdbContext context, int trackId, FileDetails track);

        // Update file lyric to a track
        Task updateLyricTrackAsync(RhythmboxdbContext context, int trackId, FileDetails lyrics);

        // Download a track 
		Task getDownloadTrackAsync(RhythmboxdbContext context, int trackId);

        // Add a track to playlist
        Task postTrackToPlaylistAsync(RhythmboxdbContext context, int playlistId, int trackId);

        // Add track to album
        Task postTrackToAlbumAsync(RhythmboxdbContext context, int albumId, int trackId);

        // Delete single track from playlist
        Task deleteTrackFromPlaylistAsync(RhythmboxdbContext context, int playlistId, int trackId);

        // Delete single track from album
        Task deleteTrackFromAlbumAsync(RhythmboxdbContext context, int playlistId, int trackId);

        // Find track using character
        Task getFindTracksAsync(RhythmboxdbContext context, string searchString);

        // Get all track - for testing only
        Task getAllTracksAsync(RhythmboxdbContext context);
    }
}

