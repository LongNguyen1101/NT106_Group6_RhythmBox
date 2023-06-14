namespace RhythmBox.Repositories.Interface
{
    public interface IPlay
    {
        Task<string> getTrack(int trackID);

    }
}
