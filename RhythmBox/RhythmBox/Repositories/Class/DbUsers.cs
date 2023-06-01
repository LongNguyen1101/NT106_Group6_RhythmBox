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
			bool userExist = context.Users.Any(con => (con.UserName == userName && con.Email == email));

			await Task.Run(() =>
			{
				if (!userExist)
				{
					try
					{
						var user = new User()
						{
							UserName = userName,
							Email = email,
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

		public async Task getUserDownloadAsync(RhythmboxdbContext context, string userName, string email)
		{
			var users = context.Users
								.Where(con => (con.UserName == userName && con.Email == email));

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

		public async Task postChangePassword(RhythmboxdbContext context, string userName, string email)
		{

		}
	}
}

