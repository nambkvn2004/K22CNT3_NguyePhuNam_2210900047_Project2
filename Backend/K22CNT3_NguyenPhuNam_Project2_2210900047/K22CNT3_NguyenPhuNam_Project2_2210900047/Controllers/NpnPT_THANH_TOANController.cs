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
    public class NpnPT_THANH_TOANController : Controller
    {
        private NpnEntities db = new NpnEntities();

        // GET: NpnPT_THANH_TOAN
        public ActionResult Index()
        {
            return View(db.PT_THANH_TOAN.ToList());
        }

        // GET: NpnPT_THANH_TOAN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PT_THANH_TOAN pT_THANH_TOAN = db.PT_THANH_TOAN.Find(id);
            if (pT_THANH_TOAN == null)
            {
                return HttpNotFound();
            }
            return View(pT_THANH_TOAN);
        }

        // GET: NpnPT_THANH_TOAN/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NpnPT_THANH_TOAN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPTTT,Ten_PTTT,Trang_thai")] PT_THANH_TOAN pT_THANH_TOAN)
        {
            if (ModelState.IsValid)
            {
                db.PT_THANH_TOAN.Add(pT_THANH_TOAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pT_THANH_TOAN);
        }

        // GET: NpnPT_THANH_TOAN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PT_THANH_TOAN pT_THANH_TOAN = db.PT_THANH_TOAN.Find(id);
            if (pT_THANH_TOAN == null)
            {
                return HttpNotFound();
            }
            return View(pT_THANH_TOAN);
        }

        // POST: NpnPT_THANH_TOAN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPTTT,Ten_PTTT,Trang_thai")] PT_THANH_TOAN pT_THANH_TOAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pT_THANH_TOAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pT_THANH_TOAN);
        }

        // GET: NpnPT_THANH_TOAN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PT_THANH_TOAN pT_THANH_TOAN = db.PT_THANH_TOAN.Find(id);
            if (pT_THANH_TOAN == null)
            {
                return HttpNotFound();
            }
            return View(pT_THANH_TOAN);
        }

        // POST: NpnPT_THANH_TOAN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PT_THANH_TOAN pT_THANH_TOAN = db.PT_THANH_TOAN.Find(id);
            db.PT_THANH_TOAN.Remove(pT_THANH_TOAN);
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
