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

//Orginal
namespace HIMS.Controllers
{



    public class AdminstrationController : Controller
    {
        private ModelsContext db = new ModelsContext();

        // GET: Adminstration
        public ActionResult ListOfAdmins()
        {



            return View(db.userAccount.ToList());


        }




        // GET: Adminstration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adminstration adminstration = db.userAccount.Find(id);
            if (adminstration == null)
            {
                return HttpNotFound();
            }
            return View(adminstration);
        }

        // GET: Adminstration/AddAdmin
        public ActionResult AddAdmin()
        {
       

            return View();
        }


       
        // POST: Adminstration/AddAdmin


        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAdmin([Bind(Include = "ID,FirstName,LastName,UserName,Password,ConfirmPassword")] Adminstration adminstration)
        {

            Adminstration admin = new Adminstration();

        
      
      

            if (ModelState.IsValid)
            {
                db.userAccount.Add(adminstration);
               db.SaveChanges();
                int LastID = db.userAccount.Max(t => t.ID);
                string CustomPattern = "Ad-" + LastID.ToString() + "-" + DateTime.Now.ToString("MM-yy");
              //  admin.ID = CustomPattern.ToString();



                return RedirectToAction("ListOfAdmins");
            }


            return View(adminstration);
        }



        // GET: Adminstration/Edit/5
        public ActionResult UpdateInfo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adminstration adminstration = db.userAccount.Find(id);
            if (adminstration == null)
            {
                return HttpNotFound();
            }
            return View(adminstration);
        }

        // POST: Adminstration/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateInfo([Bind(Include = "UserID,FirstName,LastName,UserName,Password,ConfirmPassword")] Adminstration adminstration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminstration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListOfAdmins");
            }
            return View(adminstration);
        }



        // GET: Adminstration/DeleteAdmin/5
        public ActionResult DeleteAdmin(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adminstration adminstration = db.userAccount.Find(id);
            if (adminstration == null)
            {
                return HttpNotFound();
            }
            return View(adminstration);
        }

        // POST: Adminstration/DeleteAdmin/5
        [HttpPost, ActionName("DeleteAdmin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAdminConfirmed(int id)
        {
            Adminstration adminstration = db.userAccount.Find(id);
            db.userAccount.Remove(adminstration);
            db.SaveChanges();
            return RedirectToAction("ListOfAdmins");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Adminstration admin)
        {


            using (ModelsContext db = new ModelsContext())
            {


                var usr = db.userAccount.Where(u => u.UserName == admin.UserName && u.Password == admin.Password).FirstOrDefault();


                if (usr != null)
                {


                    Session["ID"] = usr.ID.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                    return Redirect("~/Main/COO");


                }
                else { ModelState.AddModelError("", "Username Or Password is incorect.Please Try Again Later"); }



            }



            return View();
        }

        public ActionResult LoggedIn()
        {

            if (Session["UserID"] != null) { return View(); }
            else { return RedirectToAction("Login"); }

        }

    }
}
