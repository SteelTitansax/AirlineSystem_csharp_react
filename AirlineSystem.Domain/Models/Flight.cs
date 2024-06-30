namespace AirlineSystem.Domain.Models
{
    public class Flight
    {
        public string FlightNumber { get; set; }
        public string DepartureAirport { get; set; }
        public string DestinationAirport { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int Capacity { get; set; }
        public int RemainingSeats { get; set; }
        public decimal TicketPrice { get; set; }

        public List<Ticket> Tickets { get; set; }

        public Flight(string flightNumber, string departureAirport, string destinationAirport, DateTime departureTime, DateTime arrivalTime, int capacity, decimal ticketPrice)
        {
            FlightNumber = flightNumber;
            DepartureAirport = departureAirport;
            DestinationAirport = destinationAirport;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Capacity = capacity;
            RemainingSeats = capacity;
            TicketPrice = ticketPrice;
            Tickets = new List<Ticket>();
        }

        public void GetFlightDetails()
        {
            Console.WriteLine($"Flight {FlightNumber}");
            Console.WriteLine($"From {DepartureAirport} To {DestinationAirport}");
            Console.WriteLine($"Departure Time: {DepartureTime}, Arrival Time: {ArrivalTime}");
            Console.WriteLine($"Remaining Seats: {RemainingSeats}/{Capacity}");
            Console.WriteLine($"Ticket Price: ${TicketPrice}");
        }

        public int CheckAvailableSeats()

        {
            return RemainingSeats;
        }

        public void BookSeat(Ticket ticket)
        {
            if (RemainingSeats > 0)
            {
                Tickets.Add(ticket);
                RemainingSeats--;
                ticket.Passenger.Tickets.Add(ticket);
            }
            else
            {
                Console.WriteLine("No available seats on this flight.");
            }
        }

    }
}
