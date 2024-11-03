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
    public class NpnSAN_PHAM_CTController : Controller
    {
        private NpnEntities db = new NpnEntities();

        // GET: NpnSAN_PHAM_CT
        public ActionResult Index()
        {
            var sAN_PHAM_CT = db.SAN_PHAM_CT.Include(s => s.SAN_PHAM);
            return View(sAN_PHAM_CT.ToList());
        }

        // GET: NpnSAN_PHAM_CT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM_CT sAN_PHAM_CT = db.SAN_PHAM_CT.Find(id);
            if (sAN_PHAM_CT == null)
            {
                return HttpNotFound();
            }
            return View(sAN_PHAM_CT);
        }

        // GET: NpnSAN_PHAM_CT/Create
        public ActionResult Create()
        {
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "Ten_sp");
            return View();
        }

        // POST: NpnSAN_PHAM_CT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSPCT,So_luong,MaSP")] SAN_PHAM_CT sAN_PHAM_CT)
        {
            if (ModelState.IsValid)
            {
                db.SAN_PHAM_CT.Add(sAN_PHAM_CT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "Ten_sp", sAN_PHAM_CT.MaSP);
            return View(sAN_PHAM_CT);
        }

        // GET: NpnSAN_PHAM_CT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM_CT sAN_PHAM_CT = db.SAN_PHAM_CT.Find(id);
            if (sAN_PHAM_CT == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "Ten_sp", sAN_PHAM_CT.MaSP);
            return View(sAN_PHAM_CT);
        }

        // POST: NpnSAN_PHAM_CT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSPCT,So_luong,MaSP")] SAN_PHAM_CT sAN_PHAM_CT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sAN_PHAM_CT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "Ten_sp", sAN_PHAM_CT.MaSP);
            return View(sAN_PHAM_CT);
        }

        // GET: NpnSAN_PHAM_CT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM_CT sAN_PHAM_CT = db.SAN_PHAM_CT.Find(id);
            if (sAN_PHAM_CT == null)
            {
                return HttpNotFound();
            }
            return View(sAN_PHAM_CT);
        }

        // POST: NpnSAN_PHAM_CT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SAN_PHAM_CT sAN_PHAM_CT = db.SAN_PHAM_CT.Find(id);
            db.SAN_PHAM_CT.Remove(sAN_PHAM_CT);
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
