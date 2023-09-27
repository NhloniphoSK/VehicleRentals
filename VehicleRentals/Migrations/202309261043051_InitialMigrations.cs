namespace VehicleRentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        BranchName = c.String(),
                        PhysicalAddress = c.String(),
                        Email = c.String(),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BranchId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Surname = c.String(),
                        DateofBirth = c.DateTime(nullable: false),
                        Email = c.String(),
                        Phone = c.Int(nullable: false),
                        Booked = c.String(),
                        Branch_BranchId = c.Int(),
                    })
                .PrimaryKey(t => t.DriverId)
                .ForeignKey("dbo.Branches", t => t.Branch_BranchId)
                .Index(t => t.Branch_BranchId);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        PickUpDate = c.DateTime(nullable: false),
                        DropOffDate = c.DateTime(nullable: false),
                        Price = c.String(),
                        Branch_BranchId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .ForeignKey("dbo.Branches", t => t.Branch_BranchId)
                .Index(t => t.ClientId)
                .Index(t => t.DriverId)
                .Index(t => t.VehicleId)
                .Index(t => t.Branch_BranchId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        ClientName = c.String(),
                        PhysicalAddress = c.String(),
                        City = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        VehicleRegistration = c.String(),
                        VIN = c.String(),
                        Make = c.String(),
                        Model = c.String(),
                        Year = c.DateTime(nullable: false),
                        Color = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                        VehicleStatus = c.String(),
                        RentalFee = c.Double(nullable: false),
                        BranchId = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.BranchId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(),
                        PhysicalAddress = c.String(),
                        City = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Vehicles", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Rentals", "Branch_BranchId", "dbo.Branches");
            DropForeignKey("dbo.Drivers", "Branch_BranchId", "dbo.Branches");
            DropForeignKey("dbo.Rentals", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Rentals", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Rentals", "ClientId", "dbo.Clients");
            DropIndex("dbo.Vehicles", new[] { "SupplierId" });
            DropIndex("dbo.Vehicles", new[] { "BranchId" });
            DropIndex("dbo.Rentals", new[] { "Branch_BranchId" });
            DropIndex("dbo.Rentals", new[] { "VehicleId" });
            DropIndex("dbo.Rentals", new[] { "DriverId" });
            DropIndex("dbo.Rentals", new[] { "ClientId" });
            DropIndex("dbo.Drivers", new[] { "Branch_BranchId" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Clients");
            DropTable("dbo.Rentals");
            DropTable("dbo.Drivers");
            DropTable("dbo.Branches");
        }
    }
}
