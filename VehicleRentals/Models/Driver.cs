using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleRentals.Models
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Booked { get; set; }

        //Relationship
        public List<Rental> Rentals { get; set; }
    }

}