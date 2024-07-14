using RebelRescue.Api;
using RebelRescue.Spi;
using RebelRescue.Swapi.Client;

namespace RebelRescue.WebApi;

public class StartUp
{
    public void InjectDependencies(IServiceCollection services) {
        services.AddSingleton<IAssembleAFleet, FleetAssembler>();
        services.AddSingleton<IStarShipInventory, SwapiHttpClient>();
    }

    public void Start(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        InjectDependencies(builder.Services);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        app.Run();
    }
}