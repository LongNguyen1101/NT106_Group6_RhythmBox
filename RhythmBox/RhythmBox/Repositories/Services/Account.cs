using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RhythmBox.Data;
using RhythmBox.Models;
using RhythmBox.Repositories.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RhythmBox.Repositories.Services
{
    public class Account : IAccount
    {
        private User? getEmail(RhythmboxdbContext dbContext, string email)
        {
            try
            {
                var exist = (from perUser in dbContext.Users
                             where perUser.Email == email
                             select perUser).FirstOrDefault();

                if (exist == null)
                {
                    return null;
                }

                return exist;
            }
            catch { return null; }
        }

        public User? Register(RhythmboxdbContext dbContext, string userName, string email, string password, string birthday, string gender)
        {
            var exist = getEmail(dbContext, email);

            if (exist != null)
            {
                return null;
            }

            var user = new User()
            {
                UserName = userName,
                Email = email.ToLower(),
                UserPassword = password,
                AvaUrl = "https://rhythmboxstorage.file.core.windows.net/resource/users/Defaut/defaultAva.jpeg",
                Birthday = DateTime.Parse(birthday),
                Gender = gender
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return user;
        }

        public string? Login(RhythmboxdbContext dbContext,IConfiguration config, string email, string password) 
        {
            var exist = getEmail(dbContext, email);
            if (exist == null)
            {
                return "User not found";
            }
            if (exist.UserPassword != password)
            {
                return "Wrong password";
            }
            if (exist.ArtistsId != null)
            {
                CreateTokenArtist(exist, config);
            }
            return CreateTokenUser(exist, config) ;
        }

        private string CreateTokenUser(User user, IConfiguration configuration)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.UsersId.ToString()),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Role, "User")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private string CreateTokenArtist(User user, IConfiguration configuration)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.UsersId.ToString()),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
