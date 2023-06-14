using RhythmBox.Data;

namespace RhythmBox.Repositories.Interface
{
	public interface ITrack
	{
        // Add new track
        Task<string> postAddTrack(RhythmboxdbContext context, int albumId, int artistId, string title, TimeSpan duration,
                                                string genre, DateTime releaseDate, int plays, byte[] song, byte[] lyrics);

        // Delete track
        Task<string> deleteTrack(RhythmboxdbContext context, int trackId);

        // Update track
        Task<string> updateTrack(RhythmboxdbContext context, int trackId, string title, string genre, DateTime releaseDate);
    }
}

