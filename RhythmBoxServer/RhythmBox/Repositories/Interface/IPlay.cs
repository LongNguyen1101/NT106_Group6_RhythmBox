namespace RhythmBox.Repositories.Interface
{
    public interface IPlay
    {
        Task<(int, string?, TimeSpan?, byte[])?> getTrack(int trackID);
    }
}
