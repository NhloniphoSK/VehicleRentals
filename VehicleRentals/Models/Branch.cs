using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleRentals.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string PhysicalAddress { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }

        //Relationships
        public List<Vehicle> vehicles { get; set; }
        public List<Rental> rentals { get; set; }
        public List<Driver> drivers { get; set; }
    }
}