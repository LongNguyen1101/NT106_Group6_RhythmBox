using System;
namespace RhythmBox.Repositories
{
    public interface IFileShare
    {
        Task fileUploadAsync(FileDetails fileDetails, string Id, string atribtute);
        Task fileDownloadAsync(string fileSharePath);
    }
}

