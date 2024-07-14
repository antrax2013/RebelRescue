namespace RebelRescue.Spi.Stubs;

public class StarShipInventory : IStarShipInventory
{
    public async Task<IEnumerable<Starship>> GetStarships()
    {
        return await Task.FromResult<IEnumerable<Starship>>([
            new Starship("no-passenger-ship", 0, 100),
            new Starship("xs-ship", 10, 50),
            new Starship("s-ship", 50, 20),
            new Starship("m-ship", 200, 15),
            new Starship("l-ship", 800, 15),
            new Starship("xl-ship", 2000, 10),
        ]);
    }
}
