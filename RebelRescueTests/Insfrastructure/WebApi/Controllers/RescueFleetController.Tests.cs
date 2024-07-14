using Microsoft.AspNetCore.Mvc;
using NFluent;
using RebelRescue;
using RebelRescue.Api;
using RebelRescue.Spi;
using RebelRescue.Spi.Stubs;
using RebelRescue.WebApi.Controllers;
using RebelRescue.WebApi.Resources;

namespace RebelRescueTests.Insfrastructure.WebApi.Controllers;

public partial class RescueFleetControllerTests
{

    private readonly IAssembleAFleet assembleAFleet = new FleetAssembler(new StarShipInventory());
    private RescueFleetController controller;

    [SetUp]
    public void Setup()
    {
        controller = new(assembleAFleet);
    }

    [TearDown]
    public void TearDown() {
        controller.Dispose();
    }

    [Test]
    public async Task Should_Assemble_A_Fleet_For_1050_Passengers()
    {
        // Given
        int numberOfPassengers = 1050;
        IStarShipInventory starShipInventory = new StarShipInventory();
        IAssembleAFleet assembleAFleet = new FleetAssembler(starShipInventory);

        // When 
        var result = await controller.GetRescueFleet(numberOfPassengers);

        // Then
        if (result == null) 
            Assert.Fail();

        Check.That(result).IsInstanceOf<OkObjectResult>();

#pragma warning disable CS8602 // Déréférencement d'une éventuelle référence null.
        var fleet = (result as OkObjectResult).Value as FleetResource;
#pragma warning restore CS8602 // Déréférencement d'une éventuelle référence null.

        var fleetCapacity = (from startship in fleet?.Starships select startship.Capacity).Sum();
        Check.That(fleetCapacity).IsGreaterOrEqualThan(numberOfPassengers);


    }
}