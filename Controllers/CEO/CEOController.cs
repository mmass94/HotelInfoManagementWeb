using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HIMS.Context;
using HIMS.Models;
using System.Data.Entity;
namespace HIMS.Controllers
{
    public class CEOController : Controller
    {


        private CEO ceo = new CEO();
        private ModelsContext dbd = new ModelsContext();
        // GET: CEO


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(CEO user)
        {


            using (ModelsContext db = new ModelsContext())
            {


                var usr = db.ceo.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();


                if (usr != null)
                {


                    Session["UserID"] = usr.ID.ToString();
                    Session["Username"] = usr.UserName.ToString();
                    return Redirect("~/Main/CEO");


                }
                else { ModelState.AddModelError("", "Username Or Password is incorect.Please Try Again Later"); }



            }



            return View();
        }



    }
}