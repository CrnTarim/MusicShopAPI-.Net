using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MusicShop.Business.Concrete;
using MusicShop.Business.Interface;
using MusicShop.Common.Mappers;
using MusicShop.Data.Dto.InComing.CreationDto.User;
using MusicShop.Data.Dto.OutComing.Song;
using MusicShop.Data.Dto.OutComing.User;
using MusicShop.Data.Entities.Authorization;
using MusicShop.Data.Entities.Logging;
using MusicShop.Data.Entities.Song;
using MusicShop.Data.Entities.UserInfo;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using MusicShop.Business.Concrete; 



namespace MusıcShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserBusiness _business;

        public IMapper _mapper;

        public LogService _logService;

        IConfiguration _configuration;


        public UserController(IUserBusiness business, IMapper mapper,IConfiguration configuration, LogService logService)
        {
            _business = business;
            _mapper = mapper;
            _configuration = configuration;
            _logService = logService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(CreationDtoForUser userdto)
        {
            User user = _mapper.Map<User>(userdto);
            await _business.AddAsync(user);
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUser()
        {
            // Asenkron metodu bekleyin
            List<User> users = _business.GetAllAsync().ToList();

            // Null kontrolü yapın
            if (users == null || users.Count == 0)
            {
                return NotFound("No users found.");
            }

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            User user = await _business.GetbyIdAsync(id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }


        [HttpPost("register")]
        public async Task<ActionResult<User>>Register(UserDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User()
            {
                Id= Guid.NewGuid(),
                UserName = request.UserName,
                Email = request.Email,
                PasswordHash = passwordHash,
                Status =1,
                CreatedDate= DateTime.Now
            };

            await _business.AddAsync(user);

            return Ok(user);
        }


        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserDto request)
        {
            try
            {
                User user = await _business.FirstOrDefault(u => u.Email == request.Email);

                if (user == null)
                {
                    await _logService.LogAsync($"Login failed for email: {request.Email}. Reason: User not found.", LogLevels.Warning);
                    return BadRequest("User Not Found");
                }

                if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                {
                    await _logService.LogAsync($"Login failed for email: {request.Email}. Reason: Incorrect password.", LogLevels.Warning);
                    return BadRequest("Wrong password");
                }

                await _logService.LogAsync($"User {user.Email} logged in successfully.", LogLevels.Information);
                return Ok(user.Id);
            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync(ex);
                return StatusCode(500, "Internal server error");
            }
        }


        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

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
