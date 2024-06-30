using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineSystem.Domain.Models
{
    public class Passenger
    {
        public string PassengerId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public List<Ticket> Tickets { get; set; }

        public Passenger(string name, string email , string phoneNumber) 
        {
            PassengerId = new Guid().ToString();
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Tickets = new List<Ticket>();

        }
        public void GetPassengerDetails()
        {
            Console.WriteLine($"Passenger ID: {PassengerId}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"PhoneNumber: {PhoneNumber}");

        }
    }
}
