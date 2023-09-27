using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleRentals.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string PhysicalAddress { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //relationship
        public List<Rental> Rentals { get; set; }
    }
}