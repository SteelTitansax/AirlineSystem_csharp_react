using AirlineSystem.Application.Interfaces;
using AirlineSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IBookingService _bookingService; 

        public BookingController(ILogger<BookingController> logger , IBookingService bookingService)
        {
            _logger = logger;
            _bookingService = bookingService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchFlights(string departure, string destination, DateTime date)
        {
            var flights= await _bookingService.SearchFlights(departure, destination, date);
            return Ok(flights);
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookFlight(BookFlightRequest request)
        {
            var passenger = new Passenger(request.Name, request.Email, request.PhoneNumber);
            var flight = await _bookingService.GetFlight(request.FlightNumber);
            await _bookingService.BookFlight(flight, passenger, "A1");
            return Ok("Flight booked successfully.");
        }

        [HttpDelete("cancel/{ticketNumber}")]

        public async Task<IActionResult> CancelBooking(string ticketNumber)
        {
            await _bookingService.CancelBooking(ticketNumber);
            return Ok("Booking canceled successfully.");
        }
    }
}
