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
							Gender = gender
						};

						context.Users.Add(user);
						context.SaveChanges();
					});
				}
				catch { return -1; } // Handling error when adding new user to database
			}
			else return 0; // return if userName or email is exist

			return 1; // return if adding new user successfull
		}

		public async Task<User?> getUserAsync(RhythmboxdbContext context, string authenticString, string password)
		{
			try
			{
				var user = await Task.Run(() => context.Users
									.Where(con => (con.UserPassword == password && (con.UserName == authenticString || con.Email == authenticString.ToLower())))
									.Select(con => new User
									{
										UserName = con.UserName,
										Email = con.Email,
										AvaUrl = con.AvaUrl,
										Birthday = con.Birthday,
										Gender = con.Gender
									})
									.SingleOrDefault());



				return user;
			} catch { return null; }
		}

		public async Task<Boolean> postChangePasswordAsync(RhythmboxdbContext context, User user, string newPassword)
		{
			try
			{
				if (user != null)
				{
					await Task.Run(() =>
					{
						user.UserPassword = newPassword;

						context.Users.Update(user);
						context.SaveChanges();
					});
				}
			}
			catch { return false; }

			return true;
		}

		public async Task<User?> getInfoOtherUserAsync(RhythmboxdbContext context, int userId)
		{
			try
			{
				var user = await Task.Run(() => context.Users
									.Where(con => (con.UsersId == userId))
									.Select(con => new User
									{
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


    }
}

