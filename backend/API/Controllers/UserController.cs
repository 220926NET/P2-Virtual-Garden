using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Models;
using Services;
using Serilog;
using System.IdentityModel.Tokens.Jwt;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;
    private readonly IUserServices _userService;
    private readonly IConfiguration _configuration;

    public UserController(ILogger<UserController> logger, IUserServices userService, IConfiguration configuration)
    {
        _logger = logger;
        _userService = userService;
        _configuration = configuration;
    }


    [HttpPost]
    [Route("register")]
    public ActionResult<User> Add(UserDto newUser)
    {
        Log.Information("Adding new User.");
        User resultUser = _userService.Add(newUser);

        if (resultUser.username != string.Empty)
        {
            _logger.LogInformation("User successfully registered");
            return Created("User successfully registered", resultUser);
        }

        _logger.LogInformation("Username already exists");
        return BadRequest("Username already exists");
    }

    [HttpPost]
    [Route("login")]
    public ActionResult<User> Login(UserDto loginUser)
    {
        _logger.LogInformation("Login check");
        User resultUser = _userService.Login(loginUser);

        if (resultUser.username != loginUser.username)
        {
            _logger.LogInformation("Login Failed");
            return BadRequest("Login Failed");
        }

        string token = CreateToken(resultUser);

        _logger.LogInformation("Login Successful");
        return Ok(token);
        
    } 

    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim> 
        {
            new Claim(ClaimTypes.Name, user.username)
        };

        SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value));

        SigningCredentials cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        JwtSecurityToken token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: cred);

        string jwt = new JwtSecurityTokenHandler().WriteToken(token);
        
        return jwt;
    }
}
