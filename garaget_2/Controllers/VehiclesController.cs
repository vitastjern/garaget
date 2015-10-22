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
        private VehicleContext db = new VehicleContext();

        // GET: Vehicles
        public ActionResult Index()
        {
            return View(db.Vehicles.ToList());
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VehicleType,RegNR,Color,Brand,Model,NRofWheels")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.CheckInTime = DateTime.Now;
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle);
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
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VehicleType,RegNR,Color,Brand,Model,NRofWheels,CheckInTime")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        public ActionResult Search()
        {
            
           // var model = db.Vehicles.Where(i => i.RegNR == "nnnnneeeeeeeeeeeeeejjjjj").ToList();
            var model = db.Vehicles.Where(i => i.RegNR == "ABC123").ToList();
            return View(model);
        }


        // [HttpPost]
        //public ViewResult Search(string sortOrder, string searchTerm = null)
        //{
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
        //    var model = 
        //            db.Vehicles
        //            .OrderBy(r => r.RegNR)
        //       //     .OrderByDescending(r => r.RegNR)
        //            .Where(r => searchTerm == null 
        //               || r.RegNR.StartsWith(searchTerm)
        //               || r.Color.StartsWith(searchTerm) 
        //               || r.Brand.StartsWith(searchTerm) 
        //               || r.Model.StartsWith(searchTerm)
        //               || r.VehicleType.ToString().StartsWith(searchTerm)// ToString() = enum 
        //               || r.NRofWheels.ToString().StartsWith(searchTerm)// ToString() = int 
        //               ).ToList();
        //    return View(model);
        //}

         [HttpPost]
         public ViewResult Search(string sortOrder, string searchString)
         {
            ViewBag.RegNRSortParm = String.IsNullOrEmpty(sortOrder) ? "RegNR_desc" : "RegNR";
            ViewBag.searchString = searchString;
              var vehicles = from s in db.Vehicles
                            select s;
             //if (!String.IsNullOrEmpty(searchString))
             //{
             //    vehicles = vehicles.Where(s => s.RegNR.Contains(searchString)
             //                         || s.VehicleType.ToString().Contains(searchString));

              //}
              //switch (sortOrder)
              //{
              //    case "RegNR_desc":
              //        vehicles = vehicles.OrderByDescending(s => s.RegNR);
              //        break;
              //    case "RegNR":
              //        vehicles = vehicles.OrderBy(s => s.RegNR);
              //        break;
              //        default:
              //        vehicles = vehicles.OrderBy(s => s.RegNR);
              //        break;
              //}
              return View(vehicles.ToList());
         }

        public ActionResult CheckOut()
        {

            var model = db.Vehicles.Where(i => i.RegNR == "nnnnneeeeeeeeeeeeeejjjjj").ToList();
            return View(model);

            //return View(db.Vehicles.ToList());
            //return HttpNotFound();
        }




        [HttpPost]
        public ActionResult CheckOut(string RegNR)
        {

            var model = db.Vehicles.Where(i => i.RegNR == RegNR).ToList();
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
                                        PageSize = Size.A4,
                                        PageOrientation = Orientation.Landscape,
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
