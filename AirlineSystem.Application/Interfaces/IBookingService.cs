using AirlineSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineSystem.Application.Interfaces
{
    public interface IBookingService
    {
        Task AddFlight(Flight flight);
        Task <List<Flight>> SearchFlights(string departure, string destination, DateTime date);
        Task<Flight> GetFlight(string flightNumber);
        Task BookFlight(Flight flight, Passenger passenger, string seatNumber);
        Task CancelBooking(string ticketNumber);
        Task InitializeFlights();
    }
}
