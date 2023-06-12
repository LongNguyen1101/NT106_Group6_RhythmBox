using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RhythmBox.Data;
using RhythmBox.Models;
using RhythmBox.Repositories.Interface;

namespace RhythmBox.Repositories.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgotPasswordController : ControllerBase
    {
        private readonly IForgotPassword _forgotPassword;
        private readonly RhythmboxdbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public ForgotPasswordController(RhythmboxdbContext context ,IForgotPassword forgotPassword, IHttpContextAccessor contextAccessor) 
        {
            _context = context;
            _forgotPassword = forgotPassword;
            _contextAccessor = contextAccessor;
        }

        [HttpPost]
        public async Task<ActionResult> ForgotPass([FromBody] string email)
        {
            int? OTP = await Task.Run(() => _forgotPassword.forgotPassword(_context, email));
            if (OTP == null) 
            {
                return BadRequest();
            }
            _contextAccessor.HttpContext!.Session.SetInt32(email, OTP.Value);
            return Ok(email);
        }

        [HttpPost("Authentication")]
        public async Task<ActionResult> authOTP([FromBody] EmailOtp model)
        {
            var storedOtp = await Task.Run(() => _contextAccessor.HttpContext!.Session.GetInt32(model.email));
            if (model.enteredOtp != storedOtp)
            {
                return BadRequest();
            }
            
            return Ok(model.email);
        }

        [HttpPost("RenewPassword")]
        public async Task<ActionResult> renewPass([FromBody] EmailNewPass model)
        {
            if (model.newPassword.IsNullOrEmpty())
            {
                return BadRequest();
            }
            
            var user = await Task.Run(() => _forgotPassword.renewPassword(_context, model.email, model.newPassword));

            if (user == null)
            {
                return BadRequest();
            }
            return Ok();
        }
    } 
}
