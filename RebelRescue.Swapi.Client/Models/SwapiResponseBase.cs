using System.Runtime.Serialization;

namespace RebelRescue.Swapi.Client.Models;

[DataContract(Namespace = "https://swapi.dev/")]
internal class SwapiResponseBase
{
    [DataMember(Name = "count")]
    public required int Count { get; set; }

    [DataMember(Name = "next")]
    public required string NextPageUrl { get; set; }

    [DataMember(Name = "previous")]
    public required string PreviousPageUrl { get; set; }

    
}
