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

    [HttpGet]
    [Route("plant/{plantName}")]
    public ActionResult<Guid> GetPlant(string plantName)
    {
        Guid id = _gardenService.GetId(plantName);
        if (id != Guid.Empty)
        {
            Log.Information($"Sent the GUID for {plantName}");
            return Ok(id);
        }
        Log.Error("Could not get plant name");
        return BadRequest("No plant name found");
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
    [Route("garden/{userId}")]
    public ActionResult<Garden> Get(Guid userId)
    {
        Garden garden = _gardenService.GetById(userId);
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
            return Ok(garden);
        }
        Log.Error("Unable to delete Garden!!!!");
        return BadRequest("Unable to delete garden");
    }

    [HttpPut]
    [Route("garden")]
    public ActionResult<Garden> Update(Garden garden)
    {
        Garden temp = _gardenService.Update(garden);
        if (new GardenValidator().isValid(temp))
        {
            Log.Information("Garden Updated!");
            return Ok(temp);
        }
        Log.Error("Unable to update garden");
        return BadRequest("Unable to update garden");
    }
}