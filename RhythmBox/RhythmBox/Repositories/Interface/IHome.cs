using RhythmBox.Data;

namespace RhythmBox.Repositories.Interface
{
    public interface IHome
    {
        public Task getAlbums();
        public Task getArtists();
        public Task getTracks();
        public Task getRecentlyPlayed();
    }
}
