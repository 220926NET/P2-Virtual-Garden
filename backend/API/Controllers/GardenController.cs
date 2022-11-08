using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Serilog;

namespace API.Controllers;

[ApiController]
[Route("api")]
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
    [Route("garden")]
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

    [HttpGet]
    [Route("garden")]
    public ActionResult<Garden> Get(Guid id)
    {
        Garden garden = _gardenService.GetById(id);
        if (new GardenValidator().isValid(garden))
        {
            Log.Information("Sent garden");
            return Ok(garden);
        }
        Log.Error("Unable to send garden");
        return BadRequest("Unable to delete garden");
    }

    [HttpDelete]
    [Route("garden")]
    public ActionResult<Garden> Delete(Garden garden)
    {
        if (new GardenValidator().isValid(_gardenService.Delete(garden)))
        {
            Log.Information("Garden Deleted");
            return Ok("Garden deleted");
        }
        Log.Error("Unable to delete Garden!!!!");
        return BadRequest("Unable to delete garden");
    }

    [HttpPut]
    [Route("garden")]
    public ActionResult<Garden> Update(Garden garden)
    {
        if (new GardenValidator().isValid(_gardenService.Update(garden)))
        {
            Log.Information("Garden Updated!");
            return Ok("Garden updated");
        }
        Log.Error("Unable to update garden");
        return BadRequest("Unable to update garden");
    }
}