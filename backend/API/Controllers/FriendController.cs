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
    private readonly IServices<FriendRelationship> _friendService;

    public FriendController(ILogger<FriendController> logger, IServices<FriendRelationship> friendService)
    {
        _logger = logger;
        _friendService = friendService;
    }

    [HttpPost]
    [Route("add-friend")]
    public ActionResult<FriendRelationship> Add(FriendRelationship friend)
    {
        FriendRelationship temp = _friendService.Add(friend);
        if (!string.IsNullOrEmpty(temp.username))
        {
            Log.Information($"Friendship between {friend.username} and {friend.friendname} registered");
            return Created("", temp);
        }
        Log.Error($"Unable to register new friendship between {friend.username} and {friend.friendname}");
        return BadRequest("Failed to register friend relationship!");
    }
}