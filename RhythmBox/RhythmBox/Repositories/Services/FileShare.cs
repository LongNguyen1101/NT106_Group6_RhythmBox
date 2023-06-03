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

		public async Task<string?> fileUploadAsync(FileContent fileDetails, string id, string atribute, bool isImage)
		{
			if (fileDetails.content != null && fileDetails.fileName != null)
			{
				// Create the share if it doesn't already exist
				await _share.CreateIfNotExistsAsync();

				// Ensure that the directory exists
				if (await _share.ExistsAsync())
				{
					// Get a reference to the sample directory
					ShareDirectoryClient directory = _share.GetDirectoryClient($"{id}/{atribute}");

					// Get a reference to a file and upload it
					await directory.CreateIfNotExistsAsync();

					if (isImage)
					{
						// Delete all file in directory if exists before adding 
						foreach (ShareFileItem fileItem in directory.GetFilesAndDirectories())
						{
							ShareFileClient file = directory.GetFileClient(fileItem.Name);
							await file.DeleteIfExistsAsync();
						}
					}

					// Ensure that the directory exists
					if (await directory.ExistsAsync())
					{
						ShareFileClient file = directory.GetFileClient(fileDetails.fileName);

						file.Create(fileDetails.content.Length);

                        using (MemoryStream memoryStream = new MemoryStream(fileDetails.content))
                        {
                            await file.UploadRangeAsync(
                                new HttpRange(0, fileDetails.content.Length),
                                memoryStream);
                        }

                        return $"https://rhythmboxstorage.file.core.windows.net/resource/{id}/{atribute}/{fileDetails.fileName}";
					}
				}
			}

			return null;
        }

        public async Task<byte[]> fileDownloadAsync(string fileSharePath)
        {
			fileSharePath = fileSharePath.Replace("https://rhythmboxstorage.file.core.windows.net/resource/", "");

			string[] path = fileSharePath.Split("/");

            ShareDirectoryClient directory = _share.GetDirectoryClient($"{path[0]}/{path[1]}");

            ShareFileClient file = directory.GetFileClient(path[2]);

            // Download the file
            ShareFileDownloadInfo download = await file.DownloadAsync();

            using (MemoryStream stream = new MemoryStream())
            {
				await download.Content.CopyToAsync(stream);
				byte[] contentBytes = stream.ToArray();

				return contentBytes;
            }
        }

		public async Task<byte[]> fileAlbumCoverDownloadAsync(string fileSharePath)
		{
			fileSharePath = fileSharePath.Replace("https://rhythmboxstorage.file.core.windows.net/resource/", "");

			string[] path = fileSharePath.Split("/");

			ShareDirectoryClient directory = _share.GetDirectoryClient($"{path[0]}/{path[1]}");

			ShareFileClient file = directory.GetFileClient($"{path[2]}/{path[3]}");

            // Download the file
            ShareFileDownloadInfo download = await file.DownloadAsync();

            using (MemoryStream stream = new MemoryStream())
            {
                await download.Content.CopyToAsync(stream);
                byte[] contentBytes = stream.ToArray();

                return contentBytes;
            }
        }
    }
}

