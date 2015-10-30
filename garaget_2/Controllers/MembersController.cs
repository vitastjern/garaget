﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using garaget_2.DataAccessLayer;
using garaget_2.Models;

namespace garaget_2.Controllers
{
    public class MembersController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Members
        //public ActionResult Index()
        //{
        //    return View(db.Members.ToList());
        //}

        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.FullNameSortParm = sortOrder == "FullName" ? "FullName_desc" : "FullName";
            ViewBag.AddressSortParm = sortOrder == "Address" ? "Address_desc" : "Address";


            ViewBag.searchString = searchString;
            var member = from s in db.Members select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                member = member.Where(s => s.FirstName.Contains(searchString)
                        || s.LastName.Contains(searchString)
                        || s.Street.Contains(searchString)
                        || s.City.Contains(searchString)
                        || s.PostalCode.Contains(searchString));
                      }

            switch (sortOrder)
            {
                case "FullName_desc":
                    member = member.OrderByDescending(s => s.FirstName);
                    break;
                case "FullName":
                    member = member.OrderBy(s => s.FirstName);
                    break;

                case "Address_desc":
                    member = member.OrderByDescending(s => s.Street);
                    break;
                case "Address":
                    member = member.OrderBy(s => s.Street);
                    break;
                default:
                    member = member.OrderByDescending(s => s.FirstName);
                    break;
            }
            return View(member.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberId,FirstName,LastName,Street,PostalCode,City")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberId,FirstName,LastName,Street,PostalCode,City")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
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
