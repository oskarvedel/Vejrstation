using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vejrstation.Interfaces;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Vejrstation.DTO;
using Vejrstation.Entities;
using static BCrypt.Net.BCrypt;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;


namespace Vejrstation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _repository;
        
        public AccountController(IAccountRepository repository)
        {
            this._repository = repository;
        }

        [HttpPost("register"),AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] AccountRequest request)
        {
            var user = await _repository.GetByUserName(request.UserName);
            if (user != null)
            {
                return BadRequest(new {success = false, message="UserName already exists, try logging in."});
            }

            var account = new Account()
            {
                UserName = request.UserName,
                PasswordHash = HashPassword(request.Password, Settings.BCryptWorkFactor)
            };
            
            var newAccount = await _repository.Create(account);
            return Created(newAccount.Id.ToString(),newAccount.UserName);
        }

        
        
        [HttpPost("Login"),AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] AccountRequest request)
        {
            var account = await _repository.GetByUserName(request.UserName);
            if (account == null)
            {
                return BadRequest(new {success = false, message="Username doesn't exits. Please register an account."});
            }
            
            
            var passWordCompare  = Verify(request.Password, account.PasswordHash);


            switch (passWordCompare)
            {
                case false:
                    return BadRequest(new {success = false, message = "Wrong password"});
                case true:
                {
                    var claims = new Claim[]
                    {
                        new Claim("UserName", account.UserName),
                        new Claim("UserId",account.Id.ToString()), 
                        new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                        new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString())
                    };
                    var token = new JwtSecurityToken(
                        new JwtHeader(new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.JwtSecret)),
                            SecurityAlgorithms.HmacSha256)),
                        new JwtPayload(claims));

                    var tokenResult =  new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(new {JWT = tokenResult});
                }
            }
        }
    }
}