namespace Jerbaco.Flights.Dtos
{
    public record BookDto(Guid FlightId, string PassengerEmail, byte NumerOfSeats);
}
