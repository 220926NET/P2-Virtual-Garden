using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Serilog;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class GardenController : ControllerBase
{

    private readonly ILogger<GardenController> _logger;
    private readonly IServices<Garden> _gardenService;

    public GardenController(ILogger<GardenController> logger, IServices<Garden> gardenService)
    {
        _logger = logger;
        _gardenService = gardenService;
    }

    [HttpPost]
    [Route("create-garden")]
    public ActionResult<Post> Add(Garden garden)
    {
        Garden temp = _gardenService.Add(garden);
        if (temp.user_id != Guid.Empty)
        {
            Log.Information($"A garden has been created for {garden.user_id}");
            return Created("", temp);
        }
        Log.Error($"Failed to create garden for {garden.user_id}");
        return BadRequest("Could not create garden");
    }
}