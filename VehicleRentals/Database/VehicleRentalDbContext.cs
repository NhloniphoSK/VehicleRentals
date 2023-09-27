using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VehicleRentals.Models;

namespace VehicleRentals.Database
{
    public class VehicleRentalDbContext : DbContext
    {
        //public VehicleRentalDbContext() : base("DefaultConnection")
        //{

        //}

        public DbSet<Client> Clients { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
            //modelBuilder.Entity<Rental>().HasKey(r => new
            //{
            //    r.ClientId,
            //    r.VehicleId,
            //    r.DriverId
            //});

            //modelBuilder.Entity<Rental>().HasOne(v => v.Vehicles).WithMany(r => r.Rentals).HasForeignKey(v => v.VehicleId);
            //modelBuilder.Entity<Rental>().HasOne(c => c.Clients).WithMany(r => r.Rentals).HasForeignKey(c => c.ClientId);
            //modelBuilder.Entity<Rental>().HasOne(d => d.Drivers).WithMany(r => r.Rentals).HasForeignKey(d => d.DriverId);

        //    base.OnModelCreating(modelBuilder);
        //}

    }
}