using System;
using RhythmBox.Data;
using RhythmBox.Models;
using System.Data.SqlClient;
using System.Data;
using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace RhythmBox.Repositories
{
	public class FileShare : IFileShare
	{
		private readonly IConfiguration _config;
		private readonly ShareClient _share;

		public FileShare(IConfiguration config)
		{
			_config = config;
			_share = new ShareClient(_config.GetConnectionString("fileShare"),
                                                _config.GetValue<string>("FileShareDetails:FileShareName"));
        }

		public async Task fileUploadAsync(FileDetails fileDetails, string Id, string atribute)
		{ 
			// Create the share if it doesn't already exist
			await _share.CreateIfNotExistsAsync();

            // Ensure that the directory exists
            if (await _share.ExistsAsync())
			{
				// Get a reference to the sample directory
				ShareDirectoryClient directory = _share.GetDirectoryClient($"{Id}/{atribute}");

				// Get a reference to a file and upload it
				await directory.CreateIfNotExistsAsync();

				// Ensure that the directory exists
				if (await directory.ExistsAsync())
				{
					ShareFileClient file = directory.GetFileClient(fileDetails.fileDetail.FileName);

					// Check path
					var filesPath = Directory.GetCurrentDirectory() + "/files";
					var fileName = Path.GetFileName(fileDetails.fileDetail.FileName);
					var filePath = Path.Combine(filesPath, fileName);

					using (FileStream stream = File.OpenRead(filePath))
					{
						file.Create(stream.Length);
						file.UploadRange(
							new HttpRange(0, stream.Length),
							stream);
					}
				}
            }
        }

        public async Task fileDownloadAsync(string fileSharePath)
        {
			fileSharePath = fileSharePath.Replace("https://rhythmboxstorage.file.core.windows.net/resource/", "");

			string[] path = fileSharePath.Split("/");

            ShareDirectoryClient directory = _share.GetDirectoryClient($"{path[0]}/{path[1]}");

            ShareFileClient file = directory.GetFileClient(path[2]);

            // Check path
            var filesPath = Directory.GetCurrentDirectory() + "/files";
            if (!System.IO.Directory.Exists(filesPath))
            {
                Directory.CreateDirectory(filesPath);
            }

            var fileName = Path.GetFileName(fileSharePath);
            var filePath = Path.Combine(filesPath, fileName);

            // Download the file
            ShareFileDownloadInfo download = file.Download();
            using (FileStream stream = File.OpenWrite(filePath))
            {
                await download.Content.CopyToAsync(stream);
            }
        }
    }
}

