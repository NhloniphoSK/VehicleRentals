using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleRentals.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        public string VehicleRegistration { get; set; }
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public string Color { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string VehicleStatus { get; set; }
        public double RentalFee { get; set; }

        //relationship
        public int BranchId { get; set; }
        //[ForeignKey("BranchId")]
        //public Branch Branches { get; set; }
        public int SupplierId { get; set; }
        //[ForeignKey("SupplierId")]
        //public Supplier Suppliers { get; set; }
    }
}