namespace RebelRescue.Spi.Stubs;

public class StarShipInventory : IStarShipInventory
{
    public IEnumerable<Starship> GetStarships()
    {
        return new[] {
            new Starship("no-passenger-ship", 0),
            new Starship("xs-ship", 10),
            new Starship("s-ship", 50),
            new Starship("m-ship", 200),
            new Starship("l-ship", 800),
            new Starship("xl-ship", 2000),
        };
    }
}
