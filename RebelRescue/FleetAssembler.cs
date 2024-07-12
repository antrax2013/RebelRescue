using RebelRescue.Api;
using RebelRescue.Spi;

namespace RebelRescue;

public class FleetAssembler(IStarShipInventory starShipInventory) : IAssembleAFleet
{
    private readonly IStarShipInventory StarShipInventory = starShipInventory;

    public Fleet ForPassengers(int numberOfPassengers)
    {
        List<Starship> starships = GetStartShisHavingPassengersCapacity().ToList();
        IEnumerable<Starship> rescueStarships = SelectStartShips(numberOfPassengers, starships);
        return new Fleet(rescueStarships);
    }

    private IEnumerable<Starship> SelectStartShips(int numberOfPassengers, List<Starship> starships)
    {
        List<Starship> fleet = [];
        int capacityOfFleet = 0;

        foreach (var starship in starships.OrderByDescending(s=> s.Capacity)) {
            fleet.Add(starship);
            capacityOfFleet+=starship.Capacity;

            if (capacityOfFleet >= numberOfPassengers) {
                return fleet;
            }
        }

        return fleet;
    }

    private IEnumerable<Starship> GetStartShisHavingPassengersCapacity()
    {
        return StarShipInventory.GetStarships().Where(s=> s.Capacity > 0).ToList();
    }
}
