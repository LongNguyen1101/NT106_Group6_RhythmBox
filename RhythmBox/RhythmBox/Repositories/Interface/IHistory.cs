using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
	public interface IHistory
	{
		// Add history
		Task<string> postAddHistory(RhythmboxdbContext context, int userId, int trackId, DateTime playedAt);

		// Delete history
		Task<string> postDeleteHistory(RhythmboxdbContext context, int historyId);

		// Show history
		Task<List<(int, int, string, DateTime?, byte[])>?> getHistoryLoading(RhythmboxdbContext context, int userId);
	}
}

