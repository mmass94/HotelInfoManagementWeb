using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HIMS.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Main()
        {
            return View();
        }

        public ActionResult CEO()
        {
            return View();
        }

        public ActionResult COO()
        {
            return View();
        }
    }
}