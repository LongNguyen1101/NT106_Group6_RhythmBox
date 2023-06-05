using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
    public interface IForgotPassword
    {
        int? forgotPassword(RhythmboxdbContext context, string email);
        public Task<User> renewPassword(RhythmboxdbContext context, string email, string newPassword);
    }
}
