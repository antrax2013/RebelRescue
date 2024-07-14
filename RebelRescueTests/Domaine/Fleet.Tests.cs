using NFluent;
using RebelRescue;
using RebelRescue.Api;
using RebelRescue.Spi;
using RebelRescue.Spi.Stubs;

namespace RebelRescueTests.Domaine;

public partial class FleetTests
{

    [Test]
    public async Task Should_Assemble_A_Fleet_For_1050_Passengers()
    {
        // Given
        int numberOfPassengers = 1050;
        IStarShipInventory starShipInventory = new StarShipInventory();
        IAssembleAFleet assembleAFleet = new FleetAssembler(starShipInventory);

        // When 
        Fleet fleet = await assembleAFleet.ForPassengers(numberOfPassengers);

        // Then
        var existsNoTransportMachins = fleet?.Starships.Where(s => s.Capacity == 0).Any() ?? false;
        var fleetCapacity = (from startship in fleet?.Starships select startship.Capacity).Sum();

        Check.That(existsNoTransportMachins).IsFalse();
        Check.That(fleetCapacity).IsGreaterOrEqualThan(numberOfPassengers);


    }
}