using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HIMS.Context;
using HIMS.Models;

namespace HIMS.Controllers
{
    public class ReservationDashboardController : Controller
    {
        private ModelsContext db = new ModelsContext();

        // GET: ReservationDashboards
        public ActionResult ListOfReservations()
        {
            return View(db.reservations.ToList());
        }

        // GET: ReservationDashboards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationDashboard reservationDashboard = db.reservations.Find(id);
            if (reservationDashboard == null)
            {
                return HttpNotFound();
            }
            return View(reservationDashboard);
        }

        // GET: ReservationDashboards/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Room_type,First_Name,Last_Name,Birth_Date,Email,Phone_Number,Check_In_Date,Check_Out_Date,Total_Payment_Due")] ReservationDashboard reservationDashboard)
        {
            if (ModelState.IsValid)
            {
                db.reservations.Add(reservationDashboard);
                db.SaveChanges();
                return RedirectToAction("ListOfReservations");
            }

            return View(reservationDashboard);
        }

        // GET: ReservationDashboards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationDashboard reservationDashboard = db.reservations.Find(id);
            if (reservationDashboard == null)
            {
                return HttpNotFound();
            }
            return View(reservationDashboard);
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatInfo([Bind(Include = "Id,Room_type,First_Name,Last_Name,Birth_Date,Email,Phone_Number,Check_In_Date,Check_Out_Date,Total_Payment_Due")] ReservationDashboard reservationDashboard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservationDashboard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListOfReservations");
            }
            return View(reservationDashboard);
        }

        // GET: ReservationDashboards/Delete/5
        public ActionResult Checkout(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationDashboard reservationDashboard = db.reservations.Find(id);
            if (reservationDashboard == null)
            {
                return HttpNotFound();
            }
            return View(reservationDashboard);
        }

        // POST: ReservationDashboards/Checkout/5
        [HttpPost, ActionName("Checkout")]
        [ValidateAntiForgeryToken]
        public ActionResult CheckoutConfirmed(int id)
        {
            ReservationDashboard reservationDashboard = db.reservations.Find(id);
            db.reservations.Remove(reservationDashboard);
            db.SaveChanges();
            return RedirectToAction("ListOfReservations");
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
