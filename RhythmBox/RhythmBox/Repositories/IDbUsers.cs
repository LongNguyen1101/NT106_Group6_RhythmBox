using System;
using RhythmBox.Data;

namespace RhythmBox.Repositories
{
	public interface IDbUsers
	{
		Task newUserUploadAsync(RhythmboxdbContext context, string userName, string email, string password, string birthday, string gender);
		Task userDownloadAsync(RhythmboxdbContext context, string userName, string email);
	}
}

