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
    private readonly IServices<User> _userService;

    public UserController(ILogger<UserController> logger, IServices<User> userService)
    {
        _logger = logger;
        _userService = userService;
    }


    [HttpPost]
    [Route("register")]
    public ActionResult<User> Add(User newUser)
    {
        Log.Information("Adding new User.");
        User returnUser = _userService.Add(newUser);

        if (returnUser.username != null && returnUser.password!= null)
        {
            Log.Information("User successfully registered");
            return Created("User successfully registered", returnUser);
        }

        Log.Information("Username already exists");
        return BadRequest("Username already exists");
    } 
}
