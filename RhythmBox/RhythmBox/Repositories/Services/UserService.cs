using RhythmBox.Repositories.Interface;
using System.Security.Claims;

namespace RhythmBox.Repositories.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        
        public UserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public string getUserID()
        {
            string result = string.Empty;
            if (_contextAccessor.HttpContext is not null)
            {
                result = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            }
            return result!;
        }
    }
}
