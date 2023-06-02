using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
	public interface IDbHistory
	{
		Task getHistoryAsync(RhythmboxdbContext context, int userId);
		Task deleteSingleTrackAsync(RhythmboxdbContext context, int userId, int trackId);
		Task deleteAllAsync(RhythmboxdbContext context, int historyId);
	}
}

