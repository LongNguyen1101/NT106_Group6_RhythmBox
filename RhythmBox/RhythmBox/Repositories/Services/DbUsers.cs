using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using RhythmBox.Data;
using RhythmBox.Models;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace RhythmBox.Repositories
{
	public class DbUsers : IDbUsers
	{
		private readonly IConfiguration _config;
		private readonly IFileShare _fileShare;

		public DbUsers(IConfiguration config, IFileShare fileShare)
		{
			_config = config;
			_fileShare = fileShare;
		}

		public async Task<int> postCreateUserAsync(RhythmboxdbContext context, string userName, string email, string password, string birthday, string gender)
		{
			bool userExist = await Task.Run(() => context.Users.Any(con => (con.UserName == userName || con.Email == email)));

			if (!userExist)
			{
				try
				{
					await Task.Run(() =>
					{
						var user = new User()
						{
							UserName = userName,
							Email = email.ToLower(),
							UserPassword = password,
							AvaUrl = "https://rhythmboxstorage.file.core.windows.net/resource/users/Defaut/defaultAva.jpeg",
							Birthday = DateTime.Parse(birthday),
							Gender = gender.ToLower()
						};

						context.Users.Add(user);
						context.SaveChanges();

						return 1;
					});
				}
				catch { return -1; } // Handling error when adding new user to database
			}

			return 0; // return if userName or email is exist
		}

		public async Task<(User?, ShareFileDownloadInfo?)> getUserAsync(RhythmboxdbContext context, string authenticString, string password)
		{
			try
			{
				var user = await Task.Run(() => context.Users
									.Where(con => (con.UserPassword == password && (con.UserName == authenticString || con.Email == authenticString.ToLower())))
									.Select(con => new User
									{
										UsersId = con.UsersId,
										UserName = con.UserName,
										Email = con.Email,
										AvaUrl = con.AvaUrl,
										Birthday = con.Birthday,
										Gender = con.Gender
									})
									.SingleOrDefault()); 

				if (user != null && user.AvaUrl != null)
				{
					ShareFileDownloadInfo ava = await _fileShare.fileDownloadAsync(user.AvaUrl);
					return (user, ava);
				}

			} catch { return (null, null); }

			return (null, null);
		}

		public async Task<int> postChangePasswordAsync(RhythmboxdbContext context, int userId, string oldPassword, string newPassword)
		{
			try
			{
				var user = await Task.Run(() => context.Users
									.Where(con => con.UsersId == userId && con.UserPassword == oldPassword)
									.SingleOrDefault());

				if (user != null)
				{
					await Task.Run(() =>
					{
						user.UserPassword = newPassword;

						context.Users.Update(user);
						context.SaveChanges();
					});
				}
				else return 0; // Wrong id or password
			}
			catch { return -1; } // Error

			return 1; // Change password successfull
		}

		public async Task<User?> getInfoOtherUserAsync(RhythmboxdbContext context, int userId)
		{
			try
			{
				var user = await Task.Run(() => context.Users
									.Where(con => (con.UsersId == userId))
									.Select(con => new User
									{
										UsersId = con.UsersId,
										UserName = con.UserName,
										Email = con.Email,
										AvaUrl = con.AvaUrl,
										Birthday = con.Birthday,
										Gender = con.Gender
									})
									.SingleOrDefault());

				return user;
			}
			catch { return null; }
		}

		public async Task<int> postChangeInformationAsync(RhythmboxdbContext context, int userId, string newUserName, string newEmail, FileDetails newAva, string newBirthday, string newGender)
		{
			var user = await Task.Run(() => context.Users
												.Where(con => con.UsersId == userId)
												.SingleOrDefault());

			string? avaUrl = await _fileShare.fileUploadAsync(newAva, "users", userId.ToString(), true);

			if (user != null && avaUrl != null)
			{
				try
				{
					await Task.Run(() =>
					{
						if (user.UserName != newUserName) user.UserName = newUserName;
						if (user.Email != newEmail) user.Email = newEmail;
						user.AvaUrl = avaUrl;
						if (user.Birthday != DateTime.Parse(newBirthday)) user.Birthday = DateTime.Parse(newBirthday);
						if (user.Gender != newGender.ToLower()) user.Gender = newGender.ToLower();

						context.Users.Update(user);
						context.SaveChanges();
					});

					return 1; // change succecssful
				}
				catch { return 0; } // Error
			}

			return -1; // User not found
		}

		public async Task<List<Playlist>?> getPlaylistAsync(RhythmboxdbContext context, int userId)
		{
			try
			{
				var playlist = await Task.Run(() => context.Playlists
														.Where(con => con.UsersId == userId)
														.ToList());

				return playlist;
			}
			catch { return null; }
		}

		public async Task<List<AlbumsLib>?> getAlbumsLibraryAsync(RhythmboxdbContext context, int userId)
		{
            try
            {
                var albumLib = await Task.Run(() => context.AlbumsLibs
                                                        .Where(con => con.UsersId == userId)
                                                        .ToList());

                return albumLib;
            }
            catch { return null; }
        }

        public async Task<List<ArtistsLib>?> getArtistsLibraryAsync(RhythmboxdbContext context, int userId)
		{
            try
            {
                var artistLib = await Task.Run(() => context.ArtistsLibs
                                                        .Where(con => con.UsersId == userId)
                                                        .ToList());

                return artistLib;
            }
            catch { return null; }
        }
    }
}

