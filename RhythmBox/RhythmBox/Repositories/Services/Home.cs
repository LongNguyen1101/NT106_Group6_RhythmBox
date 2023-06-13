using Newtonsoft.Json;
using RhythmBox.Data;
using RhythmBox.Models;
using RhythmBox.Repositories.Interface;


namespace RhythmBox.Repositories.Services
{
    public class Home : IHome
    {
        private RhythmboxdbContext _dbContext;
        private IUserService _userService;
        private IFileShare _fileShare;
        public Home(RhythmboxdbContext dbContext, IFileShare fileShare, IUserService userService)
        {
            _dbContext = dbContext;
            _fileShare = fileShare;
            _userService = userService;
        }
        public Task getAlbums()
        {
            object data = _dbContext.Albums.ToList().Join(_dbContext.Artists.ToList(), alb => alb.ArtistsId, art => art.ArtistsId, (albs, arts) =>
            {
                byte[] albumImage = _fileShare.fileAlbumCoverDownloadAsync(albs.AlbumImage!).Result;
                return new
                {
                    AlbumID = albs.AlbumsId,
                    Title = albs.Title,
                    FullName = arts.FullName,
                    AlbumImage = albumImage
                };
            }).Take(10);

            var jsonString = JsonConvert.SerializeObject(data);
            return Task.FromResult(jsonString);
        }

        public Task getArtists()
        {
            object data = _dbContext.Artists.ToList().Select(artist =>
            {
                byte[] artistImage = _fileShare.fileDownloadAsync(artist.ArtistsImage!).Result;
                return new
                {
                    ArtistID = artist.ArtistsId,
                    FullName = artist.FullName,
                    ArtistImage = artistImage
                };
            }).Take(10);

            var jsonString = JsonConvert.SerializeObject(data);
            return Task.FromResult(jsonString);
        }    
        public Task getTracks()
        {
            
            object data = _dbContext.Tracks.ToList().Join(_dbContext.Artists.ToList(), trk => trk.ArtistsId, art => art.ArtistsId, (track, artist) =>
            {
                byte[] trackImage;
                if (track.TrackImage!.Contains("Albums"))
                {
                    trackImage = _fileShare.fileAlbumCoverDownloadAsync(track.TrackImage!).Result;
                }
                else
                {
                    trackImage = _fileShare.fileDownloadAsync(track.TrackImage!).Result;
                }
                return new 
                {
                    TrackID = track.TracksId,
                    Title = track.Title,
                    FullName = artist.FullName,
                    TrackImage = trackImage
                };
            }).Take(10);
            var jsonString = JsonConvert.SerializeObject(data);
            return Task.FromResult(jsonString);   
        }
        public Task getRecentlyPlayed()
        {
            var userID = Convert.ToInt32(_userService.getUserID());
            var data = (from user in _dbContext.Users
                        join history in _dbContext.Histories on user.UsersId equals history.UsersId
                        join track in _dbContext.Tracks on history.TracksId equals track.TracksId
                        join artist in _dbContext.Artists on track.ArtistsId equals artist.ArtistsId
                        where user.UsersId == userID
                        orderby history.PlayedAt descending
                        select new
                        {
                            TrackID = track.TracksId,
                            Title = track.Title,
                            FullName = artist.FullName,
                            TrackImage = track.TrackImage
                        })
            .ToList()
            .Select(item =>
            {
                byte[] trackImage;
                if (item.TrackImage.Contains("Albums"))
                {
                    trackImage = _fileShare.fileAlbumCoverDownloadAsync(item.TrackImage).Result;
                }
                else
                {
                    trackImage = _fileShare.fileDownloadAsync(item.TrackImage).Result;
                }
                return new
                {
                    item.TrackID,
                    item.Title,
                    item.FullName,
                    TrackImage = trackImage
                };
            })
            .Take(10);

            var jsonString = JsonConvert.SerializeObject(data);
            return Task.FromResult(jsonString);
        }
    }
}
