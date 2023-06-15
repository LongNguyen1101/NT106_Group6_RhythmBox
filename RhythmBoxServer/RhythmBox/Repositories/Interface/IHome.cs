using RhythmBox.Data;

namespace RhythmBox.Repositories.Interface
{
    public interface IHome
    {
        public string getAlbums();
        public string getArtists();
        public string getTracks();
        public string getRecentlyPlayed();
        public string getProfile();
    }
}
