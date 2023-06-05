using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RhythmBox.Data;
using RhythmBox.Repositories.Interface;

namespace RhythmBox.Repositories.Controller
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class ForgotPasswordController : ControllerBase
    {
        private readonly IForgotPassword _forgotPassword;
        private readonly RhythmboxdbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserService _userService;
        public ForgotPasswordController(RhythmboxdbContext context ,IForgotPassword forgotPassword, IHttpContextAccessor contextAccessor, IUserService userService) 
        {
            _context = context;
            _forgotPassword = forgotPassword;
            _contextAccessor = contextAccessor;
            _userService = userService;
        }
        [HttpGet]
        public ActionResult<string> GetID()
        {
            return Ok(Convert.ToInt16(_userService.getUserID()));
        }
        [HttpPost]
        public async Task<ActionResult> ForgotPass(string email)
        {
            int? OTP = _forgotPassword.forgotPassword(_context, email);
            if (OTP == null) 
            {
                return BadRequest();
            }
            _contextAccessor.HttpContext.Session.SetInt32(email, OTP.Value);
            return Ok();
        }
        [HttpPost("Authentication")]
        public async Task<ActionResult> authOTP (string email,int enteredOtp)
        {
            var storedOtp = _contextAccessor.HttpContext.Session.GetInt32(email);
            if (enteredOtp != storedOtp)
            {
                return BadRequest();
            }
            
            return Ok(email);
        }
        [HttpPost("RenewPassword")]
        public async Task<ActionResult> renewPass(string email ,string newPassword)
        {
            if (newPassword.IsNullOrEmpty())
            {
                return BadRequest();
            }
            
            var user = _forgotPassword.renewPassword(_context, email, newPassword);

            if (user == null)
            {
                return BadRequest();
            }
            return Ok();
        }
    } 
}
