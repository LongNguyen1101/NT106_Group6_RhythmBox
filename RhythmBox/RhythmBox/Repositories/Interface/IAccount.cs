using Microsoft.AspNetCore.Identity;
using RhythmBox.Data;
using RhythmBox.Models;

namespace RhythmBox.Repositories.Interface
{
    public interface IAccount
    {
        public User? Register(RhythmboxdbContext dbContext, string userName, string email, string password, string birthday, string gender);
        public string? Login(RhythmboxdbContext dbcontext,IConfiguration config,string email, string password);
    }
}
