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

		public async Task postNewUserUploadAsync(RhythmboxdbContext context, string userName, string email, string password, string birthday, string gender)
		{
			bool userExist = context.Users.Any(con => (con.UserName == userName || con.Email == email));

			await Task.Run(() =>
			{
				if (!userExist)
				{
					try
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
					}
					catch { return; }
				};
			});
		}

		public async Task getUserDownloadAsync(RhythmboxdbContext context, string authenticString, string password)
		{
			var users = context.Users
								.Where(con => (con.UserPassword == password && (con.UserName == authenticString || con.Email == authenticString.ToLower())));

			var user = users.SingleOrDefault();

			if (user != null && user.AvaUrl != null)
			{
				try
				{
					await _fileShare.fileDownloadAsync(user.AvaUrl);
				}
				catch { return; }
			}
		}

		public async Task postChangePassword(RhythmboxdbContext context, User user, string newPassword)
		{
			await Task.Run(() =>
			{
				try
				{
					if (user != null)
					{
						user.UserPassword = newPassword;

						context.Users.Update(user);
						context.SaveChanges();
					}
				}
				catch { return; }
			});
		}
	}
}

