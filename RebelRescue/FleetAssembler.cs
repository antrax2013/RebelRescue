using RebelRescue.Api;
using RebelRescue.Spi;

namespace RebelRescue;

public class FleetAssembler(IStarShipInventory starShipInventory) : IAssembleAFleet
{
    private readonly IStarShipInventory StarShipInventory = starShipInventory;

    public async Task<Fleet> ForPassengers(int numberOfPassengers)
    {
        List<Starship> starships = (await GetStartShisHavingPassengersCapacity()).ToList();
        IEnumerable<Starship> rescueStarships = SelectStartShips(numberOfPassengers, starships);
        return new Fleet(rescueStarships);
    }

    private static IEnumerable<Starship> SelectStartShips(int numberOfPassengers, List<Starship> starships)
    {
        List<Starship> fleet = [];
        int capacityOfFleet = 0;

        foreach (var starship in starships.OrderByDescending(s => s.Speed).ThenByDescending(s=> s.Capacity)) {
            fleet.Add(starship);
            capacityOfFleet+=starship.Capacity;

            if (capacityOfFleet >= numberOfPassengers) {
                return fleet;
            }
        }

        return fleet;
    }

    private async Task<IEnumerable<Starship>> GetStartShisHavingPassengersCapacity()
    {
        return (await StarShipInventory.GetStarships()).ToList().Where(s=> s.Capacity > 0).ToList();
    }
}
