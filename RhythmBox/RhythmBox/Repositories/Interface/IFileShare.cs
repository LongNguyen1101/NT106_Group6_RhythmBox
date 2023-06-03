using System;
using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace RhythmBox.Repositories
{
    public interface IFileShare
    {
        Task<string?> fileUploadAsync(FileContent fileDetails, string Id, string atribtute, bool isImage);
        Task<byte[]> fileDownloadAsync(string fileSharePath);
        Task<byte[]> fileAlbumCoverDownloadAsync(string fileSharePath);
    }
}

