using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Serilog;

namespace API.Controllers;

[ApiController]
[Route("api")]
public class FriendController : ControllerBase
{

    private readonly ILogger<FriendController> _logger;
    private readonly IServices<FriendRelationship> _friendService;

    public FriendController(ILogger<FriendController> logger, IServices<FriendRelationship> friendService)
    {
        _logger = logger;
        _friendService = friendService;
    }

    // TODO: CRUD
    /*
    [HttpCRUD]
    [Route("friend")]
    public ActionResult<FriendRealationship> CRUD() {

    }
    */

    [HttpPost]
    [Route("friend")]
    public ActionResult<FriendRelationship> Add(FriendRelationship rel)
    {
        FriendRelationship temp = _friendService.Add(rel);
        if (new FriendRelationshipValidator().isValid(temp))
        {
            Log.Information("Friend Has been created");
            return Created("Created Friend", temp);
        }
        Log.Error("Failed to register friend relationship");
        return BadRequest("Unable to add friend relationship");
    }



    [HttpGet]
    [Route("friend")]
    public ActionResult<List<FriendRelationship>> Get(string username)
    {
        List<FriendRelationship> temp = _friendService.GetAll().FindAll(delegate (FriendRelationship f)
        {
            return username.Equals(f.username);
        });
        Log.Information($"Friends of {username} sent");
        return Ok(temp);
    }

    [HttpDelete]
    [Route("friend")]
    public ActionResult<bool> Delete(FriendRelationship rel)
    {
        if (new FriendRelationshipValidator().isValid(_friendService.Delete(rel)))
        {
            Log.Information($"Delete the friend relationship between {rel.username} and {rel.friendname}");
            return Ok("Deleted!");
        }
        Log.Error("Unable to delete friend relationship");
        return BadRequest("Unable to delete friend relationship");
    }
}