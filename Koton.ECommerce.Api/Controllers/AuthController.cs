using Koton.ECommerce.Business.Services.Abstract;
using Koton.ECommerce.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Koton.ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> GetToken([FromBody] UserInfoDto userInfoDto)
        {
            var token = await _loginService.LoginAsync(userInfoDto.Email, userInfoDto.PasswordHash);
            if(token.IsSuccess)
            {
                return Ok(token);
            } else 
                return Unauthorized(token.Message);
            
        }
    }
}