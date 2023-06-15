using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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

        public string getAlbums()
        {
            object data = _dbContext.Albums.ToList().Select(async albs =>
            {
                byte[] albumImage = await _fileShare.fileAlbumCoverDownloadAsync(albs.AlbumImage!);
                return new
                {
                    AlbumID = albs.AlbumsId,
                    Title = albs.Title,
                    AlbumImage = albumImage
                };
            }).Take(10);


            var jsonString = JsonConvert.SerializeObject(data);
            return jsonString!;
        }

        public string getArtists()
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
            return jsonString!;
        }

        public string getTracks()
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
            return jsonString!;
        }

        public string getRecentlyPlayed()
        {
            var userID = Convert.ToInt32(_userService.getUserID());

            var data = (from history in _dbContext.Histories 
                        join track in _dbContext.Tracks on history.TracksId equals track.TracksId
                        where history.UsersId == userID
                        orderby history.PlayedAt descending
                        select new
                        {
                            TrackID = track.TracksId,
                            Title = track.Title,
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
                    TrackImage = trackImage
                };
            })
            .Take(10);

            var jsonString = JsonConvert.SerializeObject(data);
            return jsonString!;
        }

        public string getProfile()
        {
            var user = from u in _dbContext.Users
                       where u.UsersId == Convert.ToInt32(_userService.getUserID())
                       select new
                       {
                           userName = u.UserName,
                           email = u.Email,
                           gender = u.Gender,
                           date = u.Birthday
                       };
            var jsonString = JsonConvert.SerializeObject(user);
            return jsonString!;
        }

        public bool updateProfile(string userName, string email, string gender, DateTime birthday)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UsersId == Convert.ToInt32(_userService.getUserID()));
            try
            {
                user.UserName = userName;
                user.Email = email;
                user.Gender = gender;
                user.Birthday = birthday;
                _dbContext.Update(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
