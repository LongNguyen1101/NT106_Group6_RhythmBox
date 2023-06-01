using System;
using RhythmBox.Data;

namespace RhythmBox.Repositories
{
	public interface IDbUsers
	{
		Task postNewUserUploadAsync(RhythmboxdbContext context, string userName, string email, string password, string birthday, string gender);
		Task getUserDownloadAsync(RhythmboxdbContext context, string userName, string email);
		Task postChangePassword(RhythmboxdbContext context, string userName, string email);
	}
}

