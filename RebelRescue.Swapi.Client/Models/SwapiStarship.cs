using System.Runtime.Serialization;

namespace RebelRescue.Swapi.Client.Models;

[DataContract]
internal class SwapiStarship {
    [DataMember(Name = "name")]
    public required string Name { get; set; }

    [DataMember(Name = "model")]
    public required string Model{ get; set; }

    [DataMember(Name = "starship_class")]
    public required string StarshipClass{ get; set; }

    [DataMember(Name = "manufacturer")]
    public required string Manufacturer{ get; set; }

    [DataMember(Name = "cost_in_credits")]
    public required string CostInCredits{ get; set; }

    [DataMember(Name = "length")]
    public required string Length{ get; set; }

    [DataMember(Name = "crew")]
    public required string Crew{ get; set; }

    [DataMember(Name = "passengers")]
    public required string Passengers{ get; set; }

    [DataMember(Name = "max_atmosphering_speed")]
    public required string MaxAtmospheringSpeed{ get; set; }

    [DataMember(Name = "hyperdrive_rating")]
    public required string HyperdriveRating{ get; set; }

    [DataMember(Name = "MGLT")]
    public required string Mglt{ get; set; }

    [DataMember(Name = "cargo_capacity")]
    public required string CargoCapacity{ get; set; }

    [DataMember(Name = "consumables")]
    public required string Consumables{ get; set; }

    [DataMember(Name = "films")]
    public required string[] Films{ get; set; }

    [DataMember(Name = "pilots")]
    public required string[] Pilots{ get; set; }

    [DataMember(Name = "url")]
    public required string Url{ get; set; }

    [DataMember(Name = "created")]
    public required string Created{ get; set; }

    [DataMember(Name = "edited")]
    public required string Edited { get; set; }

    public static Starship SwapiStarshipToStarship(SwapiStarship swapiStarship)
    {
        int.TryParse(swapiStarship.Passengers.Replace(",", ""), out var passengers);
        int.TryParse(swapiStarship.Passengers.Replace(" MGLT", ""), out var speed);
        return new Starship(swapiStarship.Name, passengers, speed);
    }

}
