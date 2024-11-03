using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT3_NguyenPhuNam_2210900047_Project2.Controllers
{
    public class NpnHomeController : Controller
    {
        public ActionResult NpnIndex()
        {
            return View();
        }

        public ActionResult NpnAbout()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult NpnContact()
        {
            ViewBag.msv = "2210900047";
            ViewBag.fullname = "Nguyễn Phú Nam";

            return View();
        }
    }
}