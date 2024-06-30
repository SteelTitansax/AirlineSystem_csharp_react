using AirlineSystem.Application.Interfaces;
using AirlineSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineSystem.Application.Services
{
    public class BookingService : IBookingService
    {
        private List<Flight> _flights;

        public BookingService() 
        {
            _flights = new List<Flight>();
            InitializeFlights();

        }
        public async Task AddFlight(Flight flight)
        {
            _flights.Add(flight);
        }

        public async Task BookFlight(Flight flight, Passenger passenger, string seatNumber)
        {
            var ticket = new Ticket(Guid.NewGuid().ToString(), passenger, flight, seatNumber);
            flight.BookSeat(ticket);
            // Assume payment handling here
            Console.WriteLine($"Ticket booked successfully for {passenger.Name}. Payment processed");
        }

        public async Task CancelBooking(string ticketNumber)
        {
            foreach (var flight in _flights)
            {
                var ticket = flight.Tickets.Find( t => t.TicketNumber == ticketNumber);
                if (ticket != null)
                {
                    flight.Tickets.Remove(ticket);
                    flight.RemainingSeats++;
                    ticket.Passenger.Tickets.Remove(ticket);

                    // Assume refud processing here. 
                    Console.WriteLine($"Booking canceled for ticket {ticketNumber}. Refund processed.");
                }
                break;
            }
        }

        public async Task<Flight> GetFlight(string flightNumber)
        {
            return _flights.Where(f => f.FlightNumber == flightNumber).First();
        }

        public async Task InitializeFlights()
        {
            _flights.Add(new Flight("ABC123","JFK","LAX", new DateTime(2024,03,20,08,00,00), new DateTime(2024,03,20,12,00,00),200,150));
            _flights.Add(new Flight("ABC456", "JFK", "LAX", new DateTime(2024, 03, 20, 08, 00, 00), new DateTime(2024, 03, 20, 12, 00, 00), 180, 175));
            _flights.Add(new Flight("DED456", "LAX", "JFK", new DateTime(2024, 03, 25, 10, 00, 00), new DateTime(2024, 03, 26, 14, 00, 00), 250, 300));


        }

        public async Task<List<Flight>> SearchFlights(string departure, string destination, DateTime date)
        {
            return _flights.FindAll(f => f.DepartureAirport == departure && f.DestinationAirport == destination && f.DepartureTime.Date == date.Date);
        }
    }
}
