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

        public async Task<(int, string?, TimeSpan?, byte[])?> getTrack(int trackID)
        {
            try
            {
                var track = await Task.Run(() => _dbContext.Tracks
                                                            .Where(con => con.TracksId == trackID)
                                                            .SingleOrDefault());

                if (track != null)
                {
                    var check = await updateHistory(trackID);

                    if (check.Contains("Error")) return null;
                    else return (track.TracksId, track.Title, track.Duration, await _fileShare.fileDownloadAsync(track.SongUrl!));
                }
                else return null;
            }
            catch { return null; }
        }

        private async Task<string> updateHistory(int trackID)
        {
            try
            {
                await Task.Run(() =>
                {
                    History history = new History()
                    {
                        TracksId = trackID,
                        UsersId = Convert.ToInt32(_userService.getUserID()),
                        PlayedAt = DateTime.Now
                    };

                    _dbContext.Histories.Add(history);
                    _dbContext.SaveChanges();
                });

                return "Add successful";
            }
            catch (Exception ex)
            {
                return $"Error {ex.Message}";
            }
        }
    }
}
