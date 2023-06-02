using System;
using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace RhythmBox.Repositories
{
    public interface IFileShare
    {
        Task<string?> fileUploadAsync(FileDetails fileDetails, string Id, string atribtute, bool isImage);
        Task<ShareFileDownloadInfo> fileDownloadAsync(string fileSharePath);
    }
}

