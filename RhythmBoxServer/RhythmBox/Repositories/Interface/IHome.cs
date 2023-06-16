using RhythmBox.Data;

namespace RhythmBox.Repositories.Interface
{
    public interface IHome
    {
        Task<List<(int, string?, byte[])>?> getAlbums();
        public string getArtists();
        public string getTracks();
        public string getRecentlyPlayed();
        public string getProfile();
        public bool updateProfile(string userName, string email, string gender, DateTime birthday);
    }
}
