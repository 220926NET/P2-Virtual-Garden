using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Serilog;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;
    private readonly IUserServices _userService;

    public UserController(ILogger<UserController> logger, IUserServices userService)
    {
        _logger = logger;
        _userService = userService;
    }


    [HttpPost]
    [Route("register")]
    public ActionResult<User> Add(User newUser)
    {
        Log.Information("Adding new User.");
        User resultUser = _userService.Add(newUser);

        if (resultUser.username != null && resultUser.password!= null)
        {
            _logger.LogInformation("User successfully registered");
            return Created("User successfully registered", resultUser);
        }

        _logger.LogInformation("Username already exists");
        return BadRequest("Username already exists");
    }

    [HttpPost]
    [Route("login")]
    public ActionResult<User> Login(User loginUser)
    {
        _logger.LogInformation("Login check");
        User resultUser = _userService.Login(loginUser);

        if (resultUser.id == loginUser.id)
        {
            _logger.LogInformation("Login Failed");
            return BadRequest("Login Failed");
        }

        _logger.LogInformation("Login Successful");
        return Ok("Login Successful");
        
    } 
}
