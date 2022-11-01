using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Serilog;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{

    private readonly ILogger<PostController> _logger;
    private readonly IServices<Post> _postSevice;

    public PostController(ILogger<PostController> logger, IServices<Post> postSevice)
    {
        _logger = logger;
        _postSevice = postSevice;
    }

    [HttpPost]
    [Route("create-post")]
    public ActionResult<Post> Add(Post post)
    {
        Post temp = _postSevice.Add(post);
        if (!string.IsNullOrEmpty(temp.text))
        {
            Log.Information("A post has been created on the API layer");
            return Created("", temp);
        }
        Log.Error($"Post failed to add, information: {post}");
        return BadRequest("Failed to create a post!");
    }
}
