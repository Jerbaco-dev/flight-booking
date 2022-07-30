namespace Jerbaco.Flights.Dtos
{
    public record NewPassengerDto(
        string Email,
        string FirstName,
        string Lastname,
        bool Gender);
}
