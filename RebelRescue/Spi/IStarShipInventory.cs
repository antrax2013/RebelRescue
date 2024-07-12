namespace RebelRescue.Spi;

public interface IStarShipInventory
{
    IEnumerable<Starship> GetStarships();
}
