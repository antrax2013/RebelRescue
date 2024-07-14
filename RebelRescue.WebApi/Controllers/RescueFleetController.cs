using Microsoft.AspNetCore.Mvc;
using RebelRescue.Api;
using RebelRescue.WebApi.Resources;

namespace RebelRescue.WebApi.Controllers;
[Route("api/v1/rescue-fleet")]
public class RescueFleetController(IAssembleAFleet assembleAFleet) : Controller
{
    private readonly IAssembleAFleet _assembleAFleet = assembleAFleet;

    [HttpGet]
    public async Task<IActionResult> GetRescueFleet(int numberOfPassengers) => new OkObjectResult(new FleetResource((await _assembleAFleet.ForPassengers(numberOfPassengers))));
}
