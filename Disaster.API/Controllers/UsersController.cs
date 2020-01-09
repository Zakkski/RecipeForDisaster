using System.Threading.Tasks;
using Disaster.API.Data;
using Disaster.API.Models;
using Disaster.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace Disaster.API.Controllers
{
    [Route("api/[controller]")]
    // Allows the validations in the dtos to send back errors
    // Allows framework to infer data from request w/o you have to use [FromBody] method params
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public UsersController(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegister)
        {
            // Needed if you don't have [ApiController] also [FromBody] ^^
            // if (!ModelState.IsValid)
            //     return BadRequest(ModelState);

            userForRegister.Username = userForRegister.Username.ToLower();

            if (await _repo.UserExists(userForRegister.Username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = userForRegister.Username
            };

            var createdUser = await _repo.Register(userToCreate, userForRegister.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            // claims store information that will be used to verify user with JWT token
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };
            // Server needs to sign token to compare with later
            // Key is from the appsettings and is secret
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            // The key is encrypted
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            // create the actual token components and put them together
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            // create a handler that can generate the tokens
            var tokenHandler = new JwtSecurityTokenHandler();
            // create the actual token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // return token andn write it using the handler
            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}