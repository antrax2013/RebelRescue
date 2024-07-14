namespace RebelRescue.WebApi.Resources
{
    public record FleetResource(IEnumerable<StarshipResource> Starships)
    {
        public FleetResource(Fleet fleet) : this(fleet.Starships.Select(s => new StarshipResource(s))) { }
    }
}
