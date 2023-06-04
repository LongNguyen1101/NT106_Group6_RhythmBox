using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
	public interface IDbHistory
	{
		// Get history of tracks that user listen to
		Task getHistoryAsync(RhythmboxdbContext context, int userId);

		// Delete single history of listening
		Task deleteSingleHistoryAsync(RhythmboxdbContext context, int userId, int trackId);

		// Delete all history
		Task deleteAllAsync(RhythmboxdbContext context, int historyId);
	}
}

