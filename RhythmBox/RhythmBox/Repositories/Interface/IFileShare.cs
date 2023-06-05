﻿using System;
using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace RhythmBox.Repositories.Interface
{
    public interface IFileShare
    {
        // For uploading file bios, lyrics, tracks, images to File Share
        Task<string?> fileUploadAsync(FileContent fileDetails, string Id, string atribtute, bool isImage);

        // For downloading bios, lyrics, tracks, ava of user and artist from File Share
        Task<byte[]> fileDownloadAsync(string fileSharePath);

        // For downloading album covers from File Share
        Task<byte[]> fileAlbumCoverDownloadAsync(string fileSharePath);
    }
}

