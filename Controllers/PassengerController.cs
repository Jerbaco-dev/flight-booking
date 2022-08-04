﻿using Jerbaco.Flights.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Jerbaco.Flights.Dtos;
using Jerbaco.Flights.ReadModels;

namespace Jerbaco.Flights.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private static IList<Passenger> Passengers = new List<Passenger>();

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Register(NewPassengerDto dto)
        {
            Passengers.Add(new Passenger(
                dto.Email,
                dto.FirstName,
                dto.Lastname,
                dto.Gender));

            System.Diagnostics.Debug.WriteLine(Passengers.Count);

            return CreatedAtAction(nameof(Find), new { email = dto.Email });
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<PassengerRm> Find(string email)
        {
            var passenger = Passengers.FirstOrDefault(p => p.Email == email);

            if (passenger == null) return NotFound();

            var rm = new PassengerRm(passenger.Email, passenger.FirstName, passenger.Lastname, passenger.Gender);

            return Ok(rm);
        }

        
    }
}
