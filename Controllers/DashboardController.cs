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
    public class DashboardController : Controller
    {
        private ModelsContext db = new ModelsContext();

        // GET: Dashboard
        public ActionResult ListOfVisitors()
        {
            return View(db.dashboards.ToList());
        }

        // GET: Dashboard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dashboard dashboard = db.dashboards.Find(id);
            if (dashboard == null)
            {
                return HttpNotFound();
            }
            return View(dashboard);
        }

        // GET: Dashboard/CheckinVisitor
        public ActionResult CheckinVisitor()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckinVisitor([Bind(Include = "Id,First_Name,Last_Name,Birth_Date,Phone_Number,Room_Number,Check_In_Date,Check_Out_Date,Total_Payment_Due,Advanced_Payment")] Dashboard dashboard)
        {
            if (ModelState.IsValid)
            {
                db.dashboards.Add(dashboard);
                db.SaveChanges();
                return RedirectToAction("ListOfVisitors");
            }

            return View(dashboard);
        }

        // GET: Dashboard/UpdateVisitorInfo/5
        public ActionResult UpdateVisitorInfo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dashboard dashboard = db.dashboards.Find(id);
            if (dashboard == null)
            {
                return HttpNotFound();
            }
            return View(dashboard);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateVisitorInfo([Bind(Include = "Id,First_Name,Last_Name,Birth_Date,Phone_Number,Room_Number,Check_In_Date,Check_Out_Date,Total_Payment_Due,Advanced_Payment")] Dashboard dashboard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dashboard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListOfVisitors");
            }
            return View(dashboard);
        }

        // GET: Dashboard/CheckoutVisitor/5
        public ActionResult CheckoutVisitor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dashboard dashboard = db.dashboards.Find(id);
            if (dashboard == null)
            {
                return HttpNotFound();
            }
            return View(dashboard);
        }

        // POST: Dashboard/CheckoutVisitor/5
        [HttpPost, ActionName("CheckoutVisitor")]
        [ValidateAntiForgeryToken]
        public ActionResult CheckoutVisitorConfirmed(int id)
        {
            Dashboard dashboard = db.dashboards.Find(id);
            db.dashboards.Remove(dashboard);
            db.SaveChanges();
            return RedirectToAction("ListOfVisitors");
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
