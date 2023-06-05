﻿using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using RhythmBox.Data;
using RhythmBox.Models;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using RhythmBox.Repositories.Interface;

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

					});

					return 1;
				}
				catch { return -1; } // Handling error when adding new user to database
			}

			return 0; // return if userName or email is exist
		}

		public async Task<(User?, byte[]?)> getUserAsync(RhythmboxdbContext context, string authenticString, string password)
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
					byte[] ava = await _fileShare.fileDownloadAsync(user.AvaUrl);
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

		public async Task<(User?, byte[]?)> getInfoOtherUserAsync(RhythmboxdbContext context, int userId)
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

                if (user != null && user.AvaUrl != null)
                {
                    byte[] ava = await _fileShare.fileDownloadAsync(user.AvaUrl);
                    return (user, ava);
                }
			}
			catch { return (null, null); }

			return (null, null);
		}

		public async Task<int> postChangeInformationAsync(RhythmboxdbContext context, int userId, string newUserName, string newEmail, FileContent newAva, string newBirthday, string newGender)
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

		//public async Task<List<Playlist>?> getPlaylistAsync(RhythmboxdbContext context, int userId)
		//{
		//	try
		//	{
		//		var playlist = await Task.Run(() => context.Playlists
		//												.Where(con => con.UsersId == userId)
		//												.ToList());

		//		return playlist;
		//	}
		//	catch { return null; }
		//}

		//public async Task<List<AlbumsLib>?> getAlbumsLibraryAsync(RhythmboxdbContext context, int userId)
		//{
		//          try
		//          {
		//              var albumLib = await Task.Run(() => context.AlbumsLibs
		//                                                      .Where(con => con.UsersId == userId)
		//                                                      .ToList());

		//              return albumLib;
		//          }
		//          catch { return null; }
		//      }

		//      public async Task<List<ArtistsLib>?> getArtistsLibraryAsync(RhythmboxdbContext context, int userId)
		//{
		//          try
		//          {
		//              var artistLib = await Task.Run(() => context.ArtistsLibs
		//                                                      .Where(con => con.UsersId == userId)
		//                                                      .ToList());

		//              return artistLib;
		//          }
		//          catch { return null; }
		//      }

		//      public async Task<List<(Track?, byte[]?)>?> getTracksAsync(RhythmboxdbContext context)
		//{
		//	try
		//	{
		//		var tracks = await Task.Run(() => context.Tracks
		//												.Take(100)
		//												.Select(con => new Track
		//												{
		//													TracksId = con.TracksId,
		//													AlbumsId = con.AlbumsId,
		//													ArtistsId = con.ArtistsId,
		//													Title = con.Title,
		//													Genre = con.Genre
		//												})
		//												.ToList());

		//		List<(Track?, byte[]?)> container = new List<(Track?, byte[]?)>();

		//		await Task.Run(async () =>
		//		{
		//			foreach (var track in tracks)
		//			{
		//				if (track.AlbumsId != null)
		//				{
		//					var albumImageUrl = context.Albums
		//												.Where(con => con.AlbumsId == track.AlbumsId)
		//												.Select(e => e.AlbumImage)
		//												.SingleOrDefault();

		//					if (albumImageUrl != null)
		//					{
		//						byte[]? image = await _fileShare.fileAlbumCoverDownloadAsync(albumImageUrl);

		//						if (image != null) container.Add((track, image));
		//					}
		//				}
		//				else
		//				{
		//                          var artistImageUrl = context.Artists
		//                                                      .Where(con => con.ArtistsId == track.ArtistsId)
		//                                                      .Select(e => e.ArtistsImage)
		//                                                      .SingleOrDefault();

		//                          if (artistImageUrl != null)
		//                          {
		//						byte[]? image = await _fileShare.fileAlbumCoverDownloadAsync(artistImageUrl);

		//						if (image != null) container.Add((track, image));
		//                          }
		//                      }
		//			}
		//		});


		//		return container;
		//	}
		//	catch { return null; }
		//}

		public async Task<int> deleteUserAsync(RhythmboxdbContext context, int userId)
		{
			try
			{
				var user = context.Users.FirstOrDefault(con => con.UsersId == userId);

				if (user != null)
				{
					await Task.Run(() =>
					{
						context.Users.Remove(user);
						context.SaveChanges();

					});

					return 1; // Remove successfull
				}
				else return 0; // User not found
			}
			catch { return -1; } // Error
        }

		public async Task<List<(User, byte[])>?> getFindUserAsync(RhythmboxdbContext context, string searchString)
		{
			if (!string.IsNullOrEmpty(searchString))
			{
				try
				{
					var users = await Task.Run(() => context.Users
											.Where(con => con.UserName != null && con.UserName.Contains(searchString))
											.ToList());

					List<(User, byte[])>? list = new List<(User, byte[])>();

					if (users != null)
					{
						await Task.Run(async () =>
						{
							foreach (var user in users)
							{
								if (user.AvaUrl != null)
								{
									byte[]? ava = await _fileShare.fileDownloadAsync(user.AvaUrl);

									if (ava != null) list.Add((user, ava));
								}
							}
						});

						return list;

					}
				}
				catch { return null; }
			}

			return null;
		}

		// for testing only
        public async Task<List<User>?> getAllusers(RhythmboxdbContext context)
		{
			try
			{
				var users = await Task.Run(() => context.Users.ToList());

				if (users != null) return users; 
			}
			catch { return null; }

			return null;
		}
    }
}

