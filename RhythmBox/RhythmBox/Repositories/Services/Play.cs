using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RhythmBox.Data;
using RhythmBox.Models;
using RhythmBox.Repositories.Interface;
using System.Runtime.CompilerServices;

namespace RhythmBox.Repositories.Services
{
    public class Play : IPlay
    {
        private readonly RhythmboxdbContext _dbContext;
        private readonly IFileShare _fileShare;
        private readonly IUserService _userService;

        public Play(RhythmboxdbContext dbContext, IFileShare fileShare, IUserService userService)
        {
            _dbContext = dbContext;
            _fileShare = fileShare;
            _userService = userService;
        }

        public async Task<string> getTrack(int trackID)
        {
            //var wTrack = _dbContext.Tracks.Where(track => track.TracksId == trackID).FirstOrDefault();
            var Track = _dbContext.Tracks.ToList().Join(_dbContext.Artists.ToList(), track => track.ArtistsId, artist => artist.ArtistsId, (trk, art) =>
            {
                if (trk.TracksId == trackID)
                {
                    byte[] musicData = _fileShare.fileDownloadAsync(trk.SongUrl!).Result;
                    return new
                    {
                        ID = trk.TracksId,
                        Title = trk.Title,
                        FullName = art.FullName,
                        Duration = trk.Duration,
                        MusicData = musicData
                    };
                }
                return null;  
            });
            var track = Track.Where(track =>
            {
                if (track != null)
                {
                    return (track.ID == trackID);
                }
                return false;
            });

             await updateHistory(trackID);

            var jsonString = JsonConvert.SerializeObject(track);
            return jsonString;
        }

        private Task updateHistory(int trackID)
        {
            TimeSpan ts = new TimeSpan(0, 3, 2);
            History history = new History()
            {
                TracksId = trackID,
                UsersId = Convert.ToInt32(_userService.getUserID()),
                PlayedAt = DateTime.Now
            };

            _dbContext.Histories.Add(history);

            //int maxRecords = 100; // Số lượng bản ghi tối đa được chèn
            //int newRecordsCount = _dbContext.ChangeTracker.Entries().Count(e => e.State == EntityState.Added);
            //if (newRecordsCount > maxRecords)
            //{
            //    DateTime cutoffDate = DateTime.Now.AddDays(-1);
            //    var recordsToDelete = _dbContext.Histories.Where(r => r.PlayedAt < cutoffDate);
            //    _dbContext.Histories.RemoveRange(recordsToDelete);
            //    _dbContext.SaveChanges();
            //}
            //else
            //{
                _dbContext.SaveChanges();
            //}
            return Task.CompletedTask;
        }
    }
}
