using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NFluent;
using RebelRescue.WebApi;
using System.ComponentModel;

namespace RebelRescue.E2E.Tests;

public class RebelRescueApplicationTests(WebApplicationFactory<StartUp> factory) : IClassFixture<WebApplicationFactory<StartUp>>
{
    private readonly WebApplicationFactory<StartUp> _factory = factory;

    [Fact]
    [Category("Integration")]
    public async Task Should_Get_A_Starship_To_Save_Luke()
    {
        var client = _factory.CreateClient();

        using HttpResponseMessage response = await client.GetAsync("api/v1/rescue-fleet?numberOfPassengers=1");
        Check.That(response.IsSuccessStatusCode).IsTrue();


        var content = await response.Content.ReadAsStringAsync();
        Check.That(string.IsNullOrEmpty(content)).IsFalse();
        var starships = (JsonConvert.DeserializeAnonymousType(content, new { Starships = new List<Starship>() }))?.Starships;
        Check.That(starships?.Count ?? 0).IsGreaterOrEqualThan(1);

    }
}