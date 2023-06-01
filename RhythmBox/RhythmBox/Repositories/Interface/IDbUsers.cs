using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories
{
	public interface IDbUsers
	{
		Task postNewUserUploadAsync(RhythmboxdbContext context, string userName, string email, string password, string birthday, string gender);
		Task getUserDownloadAsync(RhythmboxdbContext context, string authenticString, string password);
		Task postChangePassword(RhythmboxdbContext context, User user, string newPassword);
	}
}

