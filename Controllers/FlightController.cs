using Jerbaco.Flights.Data;
using Jerbaco.Flights.ReadModels;
using Microsoft.AspNetCore.Mvc;
using Jerbaco.Flights.Dtos;
using Jerbaco.Flights.Domain.Errors;
using Microsoft.EntityFrameworkCore;

namespace Jerbaco.Flights.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly ILogger<FlightController> _logger;
        private readonly Entities _entities;

        public FlightController(ILogger<FlightController> logger, 
            Entities entities)
        {
            _logger = logger;
            _entities = entities;
        }

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(IEnumerable<FlightRm>), 200)]
        [HttpGet]
        public IEnumerable<FlightRm> Search()
        {
            var flightRmList = _entities.Flights.Select(flight => new FlightRm(
                flight.Id,
                flight.Airline,
                flight.Price,
                new TimePlaceRm(flight.Departure.Place, flight.Departure.Time),
                new TimePlaceRm(flight.Arrival.Place, flight.Arrival.Time),
                flight.RemainingNumberOfSeats));

            return flightRmList;
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(FlightRm), 200)]
        [HttpGet("{id}")]
        public ActionResult<FlightRm> Find(Guid id)
        {
            var flight = _entities.Flights.SingleOrDefault(f => f.Id == id);

            if (flight == null)
                return NotFound();

            var readModel = new FlightRm(
                flight.Id,
                flight.Airline,
                flight.Price,
                new TimePlaceRm(flight.Departure.Place, flight.Departure.Time),
                new TimePlaceRm(flight.Arrival.Place, flight.Arrival.Time),
                flight.RemainingNumberOfSeats);

            return Ok(readModel);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Book(BookDto dto)
        {
            System.Diagnostics.Debug.WriteLine($"Booking a new flight {dto.FlightId}");

            var flight = _entities.Flights.SingleOrDefault(f => f.Id == dto.FlightId);

            if (flight == null)
                return NotFound();

            var error = flight.MakeBooking(dto.PassengerEmail, dto.NumerOfSeats);

            if (error is OverbookError)
                return Conflict(new {message = "Not enough seats available."});

            try
            {
                _entities.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Conflict(new { message = "An error occurred while booking. Please try again." });
            }

            return CreatedAtAction(nameof(Find), new { id = dto.FlightId });
        }
    }
}