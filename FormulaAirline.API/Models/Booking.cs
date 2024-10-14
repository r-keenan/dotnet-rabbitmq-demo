using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulaAirline.API.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string PassengerName { get; set; } = "";
        public string PassportNumber { get; set; } = "";
        // Origin
        public string From { get; set; } = "";
        // Destination
        public string To { get; set; } = "";
        public int Status { get; set; } 
    }
}