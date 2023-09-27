using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleRentals.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string PhysicalAddress { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //Relationship
        public List<Vehicle> vehicles { get; set; }
    }
}