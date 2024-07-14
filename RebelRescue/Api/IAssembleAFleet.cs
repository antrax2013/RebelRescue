namespace RebelRescue.Api;

public interface IAssembleAFleet
{
    Task<Fleet> ForPassengers(int numberOfPassengers);
}