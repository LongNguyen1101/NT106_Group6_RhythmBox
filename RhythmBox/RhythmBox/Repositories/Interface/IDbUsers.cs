using System;
using RhythmBox.Data;
using RhythmBox.Models;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace RhythmBox.Repositories
{
	public interface IDbUsers
	{
		Task<int> postCreateUserAsync(RhythmboxdbContext context, string userName, string email, string password, string birthday, string gender);
		Task<(User?, byte[]?)> getUserAsync(RhythmboxdbContext context, string authenticString, string password);
		Task<int> postChangePasswordAsync(RhythmboxdbContext context, int userId, string oldPassword, string newPassword);
		Task<(User?, byte[]?)> getInfoOtherUserAsync(RhythmboxdbContext context, int userId);
        Task<int> postChangeInformationAsync(RhythmboxdbContext context, int userId, string newUserName, string newEmail, FileContent newAva, string newBirthday, string newGender);
        Task<int> deleteUserAsync(RhythmboxdbContext context, int userId);
        Task<List<(User, byte[])>?> getFindUserAsync(RhythmboxdbContext context, string searchString);
		Task<List<User>?> getAllusers(RhythmboxdbContext context); // for test only
	}
}

