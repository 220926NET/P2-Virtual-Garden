using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Serilog;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FriendController : ControllerBase
{

    private readonly ILogger<FriendController> _logger;
    private readonly IServices<FriendRelationShip> _friendService;

    public FriendController(ILogger<FriendController> logger, IServices<FriendRelationShip> friendService)
    {
        _logger = logger;
        _friendService = friendService;
    }

    [HttpPost]
    [Route("add-friend")]
    public ActionResult<Post> Add(FriendRelationShip friend)
    {
        FriendRelationShip temp = _friendService.Add(friend);
        if (!string.IsNullOrEmpty(temp.username))
        {
            Log.Information("A post has been created on the API layer");
            return Created("", temp);
        }
        Log.Error($"Post failed to add, information: {temp}");
        return BadRequest("Failed to create a post!");
    }
}