using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT3_NguyenPhuNam_Project2_2210900047.Models;

namespace K22CNT3_NguyenPhuNam_Project2_2210900047.Controllers
{
    public class NpnPT_VAN_CHUYENController : Controller
    {
        private NpnEntities db = new NpnEntities();

        // GET: NpnPT_VAN_CHUYEN
        public ActionResult Index()
        {
            return View(db.PT_VAN_CHUYEN.ToList());
        }

        // GET: NpnPT_VAN_CHUYEN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PT_VAN_CHUYEN pT_VAN_CHUYEN = db.PT_VAN_CHUYEN.Find(id);
            if (pT_VAN_CHUYEN == null)
            {
                return HttpNotFound();
            }
            return View(pT_VAN_CHUYEN);
        }

        // GET: NpnPT_VAN_CHUYEN/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NpnPT_VAN_CHUYEN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPTVC,Ten_PTVC,Do_dai,Don_gia,Trang_thai")] PT_VAN_CHUYEN pT_VAN_CHUYEN)
        {
            if (ModelState.IsValid)
            {
                db.PT_VAN_CHUYEN.Add(pT_VAN_CHUYEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pT_VAN_CHUYEN);
        }

        // GET: NpnPT_VAN_CHUYEN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PT_VAN_CHUYEN pT_VAN_CHUYEN = db.PT_VAN_CHUYEN.Find(id);
            if (pT_VAN_CHUYEN == null)
            {
                return HttpNotFound();
            }
            return View(pT_VAN_CHUYEN);
        }

        // POST: NpnPT_VAN_CHUYEN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPTVC,Ten_PTVC,Do_dai,Don_gia,Trang_thai")] PT_VAN_CHUYEN pT_VAN_CHUYEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pT_VAN_CHUYEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pT_VAN_CHUYEN);
        }

        // GET: NpnPT_VAN_CHUYEN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PT_VAN_CHUYEN pT_VAN_CHUYEN = db.PT_VAN_CHUYEN.Find(id);
            if (pT_VAN_CHUYEN == null)
            {
                return HttpNotFound();
            }
            return View(pT_VAN_CHUYEN);
        }

        // POST: NpnPT_VAN_CHUYEN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PT_VAN_CHUYEN pT_VAN_CHUYEN = db.PT_VAN_CHUYEN.Find(id);
            db.PT_VAN_CHUYEN.Remove(pT_VAN_CHUYEN);
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
