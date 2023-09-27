using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleRentals.Database;
using VehicleRentals.Models;

namespace VehicleRentals.Controllers
{
    public class RentalController : Controller
    {
        VehicleRentalDbContext dbContext = new VehicleRentalDbContext();

        // GET: Rental
        public ActionResult Index()
        {
            var result = (from r in dbContext.Rentals
                          join c in dbContext.Vehicles on r.VehicleId equals c.VehicleId
                          select new RentalViewModel
                          {
                              Id = r.Id,
                              VehicleId = r.VehicleId,
                              ClientId = r.ClientId,
                              Price = r.Price,
                              PickUpDate = r.PickUpDate,
                              DropOffDate = r.DropOffDate,
                              VehicleStatus = r.Vehicles.VehicleStatus
                              //Add the vehicles status
                          }).ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult GetVehicles()
        {
            var vehicles = dbContext.Vehicles.ToList();
            return Json(vehicles, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDrivers()
        {
            var drivers = dbContext.Drivers.ToList();
            return Json(drivers, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetClientById(int id)
        {
            var client = (from c in dbContext.Clients where c.ClientId == id select c.ClientName).ToList();
            return Json(client, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CheckAvailable(string vehicleName)
        {
            var vehicleAvailable = (from v in dbContext.Vehicles where v.Make == vehicleName select v.VehicleStatus).FirstOrDefault();
            return Json(vehicleAvailable, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveRental(RentalViewModel rental)
        {
            if (ModelState.IsValid)
            {
                var vehicle = dbContext.Vehicles.SingleOrDefault(a => a.VehicleId == rental.VehicleId);
                vehicle.VehicleStatus = "No";
                dbContext.Entry(vehicle).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound("Vehicle Not Found. Please try again.");
            }
            //try
            //{

            //}
            //catch
            //{

            //}
            //dbContext.Rentals.Add(rental);

            //var vehicle = dbContext.Vehicles.SingleOrDefault(a => a.VehicleId == rental.VehicleId);
            //if (vehicle == null)
            //{
            //    return HttpNotFound("Vehicle Not Found. Please try again.");
            //}
            //else
            //{
            //    vehicle.VehicleStatus = "No";
            //    dbContext.Entry(vehicle).State = EntityState.Modified;
            //    dbContext.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            return View(rental);
        }
    }
}