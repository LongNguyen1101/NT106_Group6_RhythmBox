using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using RhythmBox.Data;
using RhythmBox.Models;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using RhythmBox.Repositories.Interface;
using NuGet.DependencyResolver;

namespace RhythmBox.Repositories.Services
{
	public class History : IHistory
	{
        private readonly IConfiguration _config;
        private readonly IFileShare _fileShare;

        public History(IConfiguration config, IFileShare fileShare)
		{
			_config = config;
			_fileShare = fileShare;
		}

        public async Task<List<(int, int, string, DateTime?, byte[])>?> getHistoryLoading(RhythmboxdbContext context, int userId)
        {
            try
            {
                var query = await Task.Run(() => from track in context.Tracks
                                                 join history in context.Histories
                                                 on track.TracksId equals history.TracksId
                                                 select new
                                                 {
                                                     history.HistoryId,
                                                     track.TracksId,
                                                     track.Title,
                                                     history.PlayedAt,
                                                     track.TrackImage
                                                 });

                var histories = query.ToList();

                if (histories != null)
                {
                    List<(int, int, string, DateTime?, byte[])> list = new List<(int, int, string, DateTime?, byte[])>();

                    await Task.Run(async () =>
                    {
                        foreach (var history in histories)
                        {
                            int historyId = history.HistoryId;
                            int trackId = history.TracksId;
                            string title = history.Title;
                            DateTime? playedAt = history.PlayedAt;
                            byte[]? songImage = history.TrackImage.Contains("Albums") ?
                                await _fileShare.fileAlbumCoverDownloadAsync(history.TrackImage) :
                                await _fileShare.fileDownloadAsync(history.TrackImage);

                            list.Add((historyId, trackId, title, playedAt, songImage));
                        }
                    });

                    return list;
                }
                return null;
            }
            catch { return null; }
        }

        public async Task<string> postAddHistory(RhythmboxdbContext context, int userId, int trackId, DateTime playedAt)
        {
            if (await Task.Run(() => !context.Tracks.Any(con => con.TracksId == trackId))) return $"Error: Track not found";

            try
            {
                await Task.Run(() =>
                {
                    var history = new RhythmBox.Models.History()
                    {
                        UsersId = userId,
                        TracksId = trackId,
                        PlayedAt = playedAt
                    };

                    context.Histories.Add(history);
                    context.SaveChanges();
                });

                return "Add successful";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public async Task<string> postDeleteHistory(RhythmboxdbContext context, int historyId)
        {
            if (await Task.Run(() => !context.Histories.Any(con => con.HistoryId == historyId))) return $"Error: History not found";

            try
            {
              
                var history = await Task.Run(() => context.Histories
                                                            .Where(con => con.HistoryId == historyId)
                                                            .SingleOrDefault());

                if (history != null)
                {
                    context.Histories.Remove(history);
                    await context.SaveChangesAsync();
                    return "Delete successful";
                }
                return "Error: history not found";
    
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}

