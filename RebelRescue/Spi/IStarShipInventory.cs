namespace RebelRescue.Spi;

public interface IStarShipInventory
{
    Task<IEnumerable<Starship>> GetStarships();
}
