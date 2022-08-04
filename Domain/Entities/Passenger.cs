namespace Jerbaco.Flights.Domain.Entities
{
    public record Passenger(
        string Email,
        string FirstName,
        string Lastname,
        bool Gender);
}
