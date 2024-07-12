using Microsoft.AspNetCore.Mvc;
using RebelRescue.Api;

namespace RebelRescue.WebApi.Controllers;
[Route("api/v1/rescue-fleet")]
public class RescueFleetController(IAssembleAFleet assembleAFleet) : Controller
{
    private readonly IAssembleAFleet _assembleAFleet = assembleAFleet;

    [HttpGet]
    public async Task<IActionResult> GetRescueFleet(int numberOfPassengers) => await Task.Run(()=>new OkObjectResult(_assembleAFleet.ForPassengers(numberOfPassengers)));
}
