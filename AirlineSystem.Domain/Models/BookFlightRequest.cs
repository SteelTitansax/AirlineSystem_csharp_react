﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineSystem.Domain.Models
{
    public class BookFlightRequest
    {
        public string FlightNumber { get; set; }
        public string Name { get; set;}
        public string Email { get; set;}
        public string PhoneNumber { get; set;}

    }
}
