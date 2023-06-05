using System;
using RhythmBox.Data;
using RhythmBox.Models;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace RhythmBox.Repositories
{
	public interface IDbUsers
	{
		// Create new user
		Task<int> postCreateUserAsync(RhythmboxdbContext context, string userName, string email, string password, string birthday, string gender);

		// Get user, use for login
		Task<(User?, byte[]?)> getUserAsync(RhythmboxdbContext context, string authenticString, string password);

		// Change password if user want to or user forgot password
		Task<int> postChangePasswordAsync(RhythmboxdbContext context, int userId, string oldPassword, string newPassword);

		// Use for getting information of others users by searching their name
		Task<(User?, byte[]?)> getInfoOtherUserAsync(RhythmboxdbContext context, int userId);

		// Chang information of user (but no change password)
        Task<int> postChangeInformationAsync(RhythmboxdbContext context, int userId, string newUserName, string newEmail, FileContent newAva, string newBirthday, string newGender);

		// Delete user
        Task<int> deleteUserAsync(RhythmboxdbContext context, int userId);

		// Get list of users by searching character
        Task<List<(User, byte[])>?> getFindUserAsync(RhythmboxdbContext context, string searchString);

		// Get all users in the database - for testing only
		Task<List<User>?> getAllusers(RhythmboxdbContext context); 
	}
}

