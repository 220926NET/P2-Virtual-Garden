using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

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
        User returnUser = _userService.Add(newUser);

        if (returnUser.username != "")
        {
            return Created("User successfully registered", returnUser);
        }

        return BadRequest("Username already exists");
    } 
}
