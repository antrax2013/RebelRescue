using System.Runtime.Serialization;

namespace RebelRescue.Swapi.Client.Models;

[DataContract(Namespace = "https://swapi.dev/api/starships/")]
internal class SwapiStarshipResponse : SwapiResponseBase
{
    [DataMember(Name = "results")]
    public required SwapiStarship[] Starships { get; set; }
}
