using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

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
}
