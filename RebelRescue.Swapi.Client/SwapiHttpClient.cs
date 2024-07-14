using Newtonsoft.Json;
using RebelRescue.Spi;
using RebelRescue.Swapi.Client.Models;

namespace RebelRescue.Swapi.Client;

public class SwapiHttpClient : IStarShipInventory
{
    private const string URL = "https://swapi.dev/api/starships/?page=1";

    private static async Task<IEnumerable<Starship>> GetNextStarShipsPages(HttpClient httpClient, string nextUrl)
    {
        var json = await httpClient.GetStringAsync(nextUrl);
        var response = JsonConvert.DeserializeObject<SwapiStarshipResponse>(json);
        IEnumerable<Starship> nextStartships = [];

        if (response == null) 
            return [];

        if (response.NextPageUrl != null)
        {
            nextStartships = await GetNextStarShipsPages(httpClient, response.NextPageUrl);
        }

        var currentStartships = Array.ConvertAll(response.Starships, new Converter<SwapiStarship, Starship>(SwapiStarship.SwapiStarshipToStarship));
        
        return currentStartships?.Concat(nextStartships ?? [])??[];

    }

    public async Task<IEnumerable<Starship>> GetStarships()
    {
        using var httpClient = new HttpClient();
        return await GetNextStarShipsPages(httpClient, URL);
    }
}
