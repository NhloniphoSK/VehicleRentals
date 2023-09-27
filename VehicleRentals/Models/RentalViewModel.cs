using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleRentals.Models
{
    public class RentalViewModel
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public string Price { get; set; }
        public string VehicleStatus { get; set; }
    }
}