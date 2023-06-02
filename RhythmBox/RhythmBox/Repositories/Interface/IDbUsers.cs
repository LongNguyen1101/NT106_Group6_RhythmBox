using System;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories
{
	public interface IDbUsers
	{
		Task<int> postCreateUserAsync(RhythmboxdbContext context, string userName, string email, string password, string birthday, string gender);
		Task<User?> getUserAsync(RhythmboxdbContext context, string authenticString, string password);
		Task<Boolean> postChangePasswordAsync(RhythmboxdbContext context, User user, string newPassword);
		Task<User?> getInfoOtherUserAsync(RhythmboxdbContext context, int userId);
		//Task postChangeInformationAsync(RhythmboxdbContext context, int userId, string userName, string email, FileDetails avaUrl, string birthday, string gender);
		//Task getPlaylistAsync(RhythmboxdbContext context, int userId);
		//Task getAlbumsLibraryAsync(RhythmboxdbContext context, int userId);
		//Task getArtistsLibraryAsync(RhythmboxdbContext context, int userId);
		//Task getTracksAsync(RhythmboxdbContext context, int trackId);
		//Task postCreatePlaylistAsync(RhythmboxdbContext context, int userId);
		//Task postCreateAlbumsLibraryAsync(RhythmboxdbContext context, int userId);
		//Task postCreateArtistsLibraryAsync(RhythmboxdbContext context, int userId);
		//Task getDownloadTracksAsync(RhythmboxdbContext context, int userId);
		//Task deleteUserAsync(RhythmboxdbContext context, int userId);
  //      Task getFindUserAsync(RhythmboxdbContext context, string searchString);
    }
}

