using Jerbaco.Flights.Domain.Entities;

namespace Jerbaco.Flights.Data
{
    public class Entities
    {
        public IList<Passenger> Passengers = new List<Passenger>();

        public List<Flight> Flights = new();
    }
}
