using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
	public interface IDbTracks
	{
		Task getTrackAsync(RhythmboxdbContext context, int trackId);
		Task postCreateTrackAsync(RhythmboxdbContext context, int albumId, int artistId, string tile,
								TimeSpan duration, string genre, DateTime releaseDate, FileDetails track, FileDetails lyrics);
		Task deleteTrackAsync(RhythmboxdbContext context, int trackId);
        Task updateInformationAsync(RhythmboxdbContext context, int albumId, int artistId, string tile,
                                TimeSpan duration, string genre, DateTime releaseDate, FileDetails track, FileDetails lyrics);
		Task getInformationAsync(RhythmboxdbContext context, int trackId);
		Task getDownloadTrackAsync(RhythmboxdbContext context, int trackId);
        Task getFindTracksAsync(RhythmboxdbContext context, string searchString);
    }
}

