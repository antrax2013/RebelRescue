namespace RebelRescue.WebApi.Resources
{
    public record StarshipResource(string Name, int Capacity) {
        public StarshipResource(Starship starship) : this(starship.Name, starship.Capacity) { }
    }
}
