using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using garaget_2.DataAccessLayer;
using garaget_2.Models;
using Rotativa.Options;

namespace garaget_2.Controllers
{
    public class VehiclesController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Vehicles
        public ViewResult Index(string sortOrder, string searchString)
        {

            ViewBag.VehicleTypeSortParm = sortOrder == "VehicleType" ? "VehicleType_desc" : "VehicleType";
            ViewBag.RegNRSortParm = sortOrder == "RegNR" ? "RegNR_desc" : "RegNR";
            ViewBag.MemberSortParm = sortOrder == "Member" ? "Member_desc" : "Member";
         
            ViewBag.searchString = searchString;
            var vehicles = from s in db.Vehicles select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                vehicles = vehicles.Where(s => s.RegNr.Contains(searchString)
                     || s.VehicleType.VehicleTypeName.Contains(searchString)
                     || s.Member.FirstName.Contains(searchString)
                     || s.Member.LastName.Contains(searchString));
                     
            }

            switch (sortOrder)
            {
                case "VehicleType_desc":
                    vehicles = vehicles.OrderByDescending(s => s.VehicleType.VehicleTypeName);
                    break;
                case "VehicleType":
                    vehicles = vehicles.OrderBy(s => s.VehicleType.VehicleTypeName);
                    break;

                case "RegNR_desc":
                    vehicles = vehicles.OrderByDescending(s => s.RegNr);
                    break;
                case "RegNR":
                    vehicles = vehicles.OrderBy(s => s.RegNr);
                    break;
                case "Member_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Member.FirstName);
                    break;
                case "Member":
                    vehicles = vehicles.OrderBy(s => s.Member.FirstName);
                    break;
                default:
                    vehicles = vehicles.OrderByDescending(s => s.RegNr);
                    break;
            }
            return View(vehicles.ToList());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create(int id)
        {
            ViewBag.MemberId = id;
            ViewBag.Member = db.Members.Where(m => m.MemberId == id).First();
            Vehicle model = new Vehicle {MemberId = id};

            //ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName");
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "VehicleTypeId", "VehicleTypeName");

            return View(model);
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleId,RegNr,Color,Brand,Model,NrOfWheels,MemberId,VehicleTypeId")] Vehicle vehicle2)
        {
            if (ModelState.IsValid)
            {
                //vehicle2.VehicleTypeId = 3;
                vehicle2.CheckInTime = DateTime.Now;
                db.Vehicles.Add(vehicle2);
                db.SaveChanges();
                return RedirectToAction("Search");
            }

            return View(vehicle2);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName", vehicle.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "VehicleTypeId", "VehicleTypeName", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleId,RegNr,Color,Brand,Model,NrOfWheels,CheckInTime,MemberId,VehicleTypeId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Search");
            }
            return View(vehicle);
        }
        
        // [HttpPost]
        public ViewResult Search(string sortOrder, string searchString)
        {

            ViewBag.VehicleTypeSortParm = sortOrder == "VehicleType" ? "VehicleType_desc" : "VehicleType";
            ViewBag.RegNRSortParm = sortOrder == "RegNR" ? "RegNR_desc" : "RegNR";
            ViewBag.ColorSortParm = sortOrder == "Color" ? "Color_desc" : "Color";
            ViewBag.BrandSortParm = sortOrder == "Brand" ? "Brand_desc" : "Brand";
            ViewBag.ModelSortParm = sortOrder == "Model" ? "Model_desc" : "Model";
            ViewBag.MemberSortParm = sortOrder == "Member" ? "Member_desc" : "Member";
            ViewBag.CheckInTimeSortParm = sortOrder == "CheckInTime" ? "CheckInTime_desc" : "CheckInTime";


            ViewBag.searchString = searchString;
            var vehicles = from s in db.Vehicles select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                vehicles = vehicles.Where(s => s.RegNr.Contains(searchString)
                     || s.VehicleType.VehicleTypeName.Contains(searchString)
                     || s.Color.Contains(searchString)
                     || s.Brand.Contains(searchString)
                     || s.Member.FirstName.Contains(searchString)
                     || s.Member.LastName.Contains(searchString)
                     || s.Model.Contains(searchString));
      

            }

            switch (sortOrder)
            {
                case "VehicleType_desc":
                    vehicles = vehicles.OrderByDescending(s => s.VehicleType.VehicleTypeName);
                    break;
                case "VehicleType":
                    vehicles = vehicles.OrderBy(s => s.VehicleType.VehicleTypeName);
                    break;

                case "RegNR_desc":
                    vehicles = vehicles.OrderByDescending(s => s.RegNr);
                    break;
                case "RegNR":
                    vehicles = vehicles.OrderBy(s => s.RegNr);
                    break;
                case "Color_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Color);
                    break;
                case "Color":
                    vehicles = vehicles.OrderBy(s => s.Color);
                    break;
                case "Brand_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Brand);
                    break;
                case "Brand":
                    vehicles = vehicles.OrderBy(s => s.Brand);
                    break;
                case "Model_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Model);
                    break;
                case "Model":
                    vehicles = vehicles.OrderBy(s => s.Model);
                    break;
                case "Member_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Member.FirstName);
                    break;
                case "Member":
                    vehicles = vehicles.OrderBy(s => s.Member.FirstName);
                    break;
                case "CheckInTime_desc":
                    vehicles = vehicles.OrderByDescending(s => s.CheckInTime);
                    break;
                case "CheckInTime":
                    vehicles = vehicles.OrderBy(s => s.CheckInTime);
                    break;
                default:
                    vehicles = vehicles.OrderByDescending(s => s.RegNr);
                    break;
            }
            return View(vehicles.ToList());
        }

        public ActionResult CheckOut()
        {

            var model = db.Vehicles.Where(i => i.RegNr == "nnnnneeeeeeeeeeeeeejjjjj").ToList();
            return View(model);
        }




        [HttpPost]
        public ActionResult CheckOut(string RegNR)
        {

            var model = db.Vehicles.Where(i => i.RegNr == RegNR).ToList();
            return View(model);

        }

        // GET: Vehicles/MemberOwnedVehicles
        public ActionResult MemberOwnedVehicles(int id)
        {
            ViewBag.MemberId = id;
            ViewBag.Member = db.Members.Where(m => m.MemberId == id).First();
       
            var model = db.Vehicles.Where(v => v.MemberId == id).ToList();
            return View(model);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);

            db.Vehicles.Remove(vehicle);
            db.SaveChanges();

            TempData["vehicle"] = vehicle;
         

            return RedirectToAction("Receipt", vehicle);
        }

        public ActionResult GeneratePDF(Vehicle v)
        {
            return new Rotativa.ActionAsPdf("Receipt", v)
                                    {
                                        FileName = "Kvitto.pdf",
                                        CustomSwitches = "--disable-smart-shrinking",
                                        PageSize = Size.A6,
                                        PageWidth = 210,
                                        PageHeight = 297
                                        
                                    };
        }
        
        public ActionResult Receipt(Vehicle v)
        {
            return View(v);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
